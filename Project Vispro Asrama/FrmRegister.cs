using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_Vispro_Asrama
{
    public partial class FrmRegister : Form
    {
        private MySqlConnection koneksi;
        private MySqlCommand perintah;
        private string alamat, query;

        // Dictionary to store asrama and respective fees
        private readonly Dictionary<string, decimal> asramaFees = new Dictionary<string, decimal>
        {
            
        };

        public FrmRegister()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            cbAsrama.SelectedIndexChanged += cbAsrama_SelectedIndexChanged;
            cbGender.SelectedIndexChanged += cbGender_SelectedIndexChanged;

        }

        private void LoadAsramaData()
        {
            try
            {
                koneksi.Open();

                // Query to get asrama and prices
                query = "SELECT nama_asrama, harga_asrama FROM asrama";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, koneksi);

                // Fill the data into a DataTable
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Assign the data source to the DataGridView
                dataGridViewAsrama.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading asrama data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.Close();
            }
        }


        private void LoadAsramaFees(string gender)
        {
            try
            {
                koneksi.Open();

                // Choose the query based on gender
                string query;
                if (gender == "Male")
                {
                    query = "SELECT nama_asrama, harga_asrama FROM asrama_boys";
                }
                else if (gender == "Female")
                {
                    query = "SELECT nama_asrama, harga_asrama FROM asrama_girls";
                }
                else
                {
                    // If no specific gender, load both boys and girls dormitories if needed
                    // Or handle the case if gender selection is invalid
                    query = ""; // Set an appropriate query or display an error if necessary
                    MessageBox.Show("Please select a valid gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Clear the dictionary to avoid duplicate entries
                asramaFees.Clear();

                // Execute the query
                using (var perintah = new MySqlCommand(query, koneksi))
                using (var reader = perintah.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string namaAsrama = reader.GetString("nama_asrama");
                        decimal harga = reader.GetDecimal("harga_asrama");
                        asramaFees[namaAsrama] = harga;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading asrama data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.Close();
            }
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            // Populate cbAsrama with the names of asrama from the dictionary
            cbAsrama.Items.AddRange(asramaFees.Keys.ToArray());
            LoadAsramaData();
            
        }

        private void cbAsrama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAsrama.SelectedItem != null && asramaFees.TryGetValue(cbAsrama.SelectedItem.ToString(), out decimal fee))
            {
                txtPembayaran.Text = fee.ToString("F0");
            }
            else
            {
                txtPembayaran.Text = "";
            }
        }


        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAsrama.Items.Clear();

            if (cbGender.SelectedItem != null)
            {
                string selectedGender = cbGender.SelectedItem.ToString();

                // Load dormitories based on selected gender
                LoadAsramaFees(selectedGender);

                // Populate cbAsrama with the loaded asrama names from the database
                cbAsrama.Items.AddRange(asramaFees.Keys.ToArray());
            }

            // Reset the selected item and clear payment field
            cbAsrama.SelectedIndex = -1;
            txtPembayaran.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInfoAsrama frmInfoAsrama = new FrmInfoAsrama();
            frmInfoAsrama.Show();
            this.Close();
        }

        private void btnCheckKamar_Click(object sender, EventArgs e)
        {
            FrmKamar frmKamar = new FrmKamar();
            frmKamar.Show();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (txtNIM.Text != "" && txtNama.Text != "" && txtKamar.Text != "" && cbGender.SelectedIndex >= 0 && cbAsrama.SelectedIndex >= 0)
            {
                try
                {
                    // Remove any formatting and parse the balance amount from txtPembayaran
                    string balanceText = txtPembayaran.Text.Replace(",", "").Trim();

                    if (!decimal.TryParse(balanceText, out decimal balance))
                    {
                        MessageBox.Show("Invalid balance amount. Please check the value in Pembayaran.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Open connection
                    koneksi.Open();

                    // Insert query to save data to the booking table
                    query = "INSERT INTO booking (nim, nama, gender, asrama, no_kamar, balance) VALUES (@NIM, @Nama, @JenisKelamin, @Asrama, @NoKamar, @Balance)";
                    perintah = new MySqlCommand(query, koneksi);

                    // Assign parameters with values from form fields
                    perintah.Parameters.AddWithValue("@NIM", txtNIM.Text);
                    perintah.Parameters.AddWithValue("@Nama", txtNama.Text);
                    perintah.Parameters.AddWithValue("@JenisKelamin", cbGender.SelectedItem.ToString());
                    perintah.Parameters.AddWithValue("@Asrama", cbAsrama.SelectedItem.ToString());
                    perintah.Parameters.AddWithValue("@NoKamar", txtKamar.Text);
                    perintah.Parameters.AddWithValue("@Balance", balance); // Pass the parsed balance here

                    // Execute query
                    perintah.ExecuteNonQuery();

                    // Show success message
                    MessageBox.Show("Data successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Show error message if any exception occurs
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the database connection
                    koneksi.Close();
                }
            }
            else
            {
                // Show warning if any required field is missing
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
