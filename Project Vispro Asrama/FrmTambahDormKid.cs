using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Vispro_Asrama
{
    public partial class FrmTambahDormKid : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FrmTambahDormKid()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void FrmTambahDormKid_Load(object sender, EventArgs e)
        {
            LoadAsramaData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNIM.Text))
                {
                    MessageBox.Show("Data Siswa Yang Anda Cari Tidak Terdaftar!");
                    return;
                }

                query = "SELECT nim, nama, asrama, no_kamar, balance, gender FROM booking WHERE nim = @nim";
                ds.Clear();

                if (koneksi.State == ConnectionState.Closed)
                {
                    koneksi.Open();
                }

                using (var perintah = new MySqlCommand(query, koneksi))
                {
                    perintah.Parameters.AddWithValue("@nim", txtNIM.Text);

                    using (var adapter = new MySqlDataAdapter(perintah))
                    {
                        adapter.Fill(ds);
                    }
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    var kolom = ds.Tables[0].Rows[0];
                    txtNIM.Text = kolom["nim"].ToString();
                    txtNamaMahasiswa.Text = kolom["nama"].ToString();
                    txtKamar.Text = kolom["no_kamar"].ToString();
                    txtAsrama.Text = kolom["asrama"].ToString();
                    txtGender.Text = kolom["gender"].ToString();
                }
                else
                {
                    MessageBox.Show("Data Siswa Tidak Terdaftar!");
                    FrmTambahDormKid_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNIM.Text = "";
            txtNamaMahasiswa.Text = "";
            txtAsrama.Text = "";
            txtGender.Text = "";
            txtKamar.Text = "";

            txtNIM.Enabled = true;
            btnAdd.Enabled = true;
            btnSearch.Enabled = true;
            btnClear.Enabled = true;

            FrmTambahDormKid_Load(null, null);
        }
      

        private void button3_Click(object sender, EventArgs e)
        {
            FrmKepas frmKepas = new FrmKepas();
            frmKepas.Show();
            this.Hide();
        }

        private void LoadAsramaData()
        {
            try
            {
                if (koneksi.State == ConnectionState.Closed)
                {
                    koneksi.Open();
                }

                query = "SELECT * FROM booking";
                adapter = new MySqlDataAdapter(query, koneksi);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadAsramaData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNIM.Text = row.Cells["nim"].Value.ToString();
                txtNamaMahasiswa.Text = row.Cells["nama"].Value.ToString();
                txtKamar.Text = row.Cells["no_kamar"].Value.ToString();
                txtAsrama.Text = row.Cells["asrama"].Value.ToString();
                txtGender.Text = row.Cells["gender"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNIM.Text != "" && txtNamaMahasiswa.Text != "" && txtKamar.Text != "")
            {
                try
                {
                    koneksi.Open();

                    // Mengecek apakah data sudah ada di tabel student_asrama
                    string checkQuery = "SELECT COUNT(*) FROM student_asrama WHERE NIM = @nim AND full_name = @nama";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, koneksi);
                    checkCommand.Parameters.AddWithValue("@nim", txtNIM.Text);
                    checkCommand.Parameters.AddWithValue("@nama", txtNamaMahasiswa.Text);

                    int exists = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show("Data dengan NIM dan Nama ini sudah ada. Data tidak ditambahkan.");
                    }
                    else
                    {
                        // Mengambil nilai balance dari tabel booking berdasarkan NIM
                        string balanceQuery = "SELECT balance FROM booking WHERE nim = @nim";
                        MySqlCommand balanceCommand = new MySqlCommand(balanceQuery, koneksi);
                        balanceCommand.Parameters.AddWithValue("@nim", txtNIM.Text);

                        decimal bayar = 0;
                        object balanceResult = balanceCommand.ExecuteScalar();

                        if (balanceResult != null && balanceResult != DBNull.Value)
                        {
                            bayar = Convert.ToDecimal(balanceResult);
                        }
                        else
                        {
                            MessageBox.Show("Balance tidak ditemukan untuk NIM ini.");
                            return;
                        }

                        // Lanjutkan dengan menambahkan data ke student_asrama
                        string email = $"{txtNIM.Text}@student.unklab.ac.id";
                        string password = "studentunklab2024";

                        string insertQuery = "INSERT INTO student_asrama (NIM, full_name, room_number, email, sisa_bayar, password, check_in, asrama) " +
                                             "VALUES (@nim, @nama, @no_kamar, @email, @bayar, @password, @checkin, @asrama)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, koneksi);
                        insertCommand.Parameters.AddWithValue("@nim", txtNIM.Text);
                        insertCommand.Parameters.AddWithValue("@nama", txtNamaMahasiswa.Text);
                        insertCommand.Parameters.AddWithValue("@no_kamar", Convert.ToInt32(txtKamar.Text));
                        insertCommand.Parameters.AddWithValue("@email", email);
                        insertCommand.Parameters.AddWithValue("@bayar", bayar); // Gunakan balance sebagai bayar
                        insertCommand.Parameters.AddWithValue("@password", password);
                        insertCommand.Parameters.AddWithValue("@checkin", dateTimePicker1.Value);
                        insertCommand.Parameters.AddWithValue("@asrama", txtAsrama.Text);

                        int res = insertCommand.ExecuteNonQuery();

                        if (res == 1)
                        {
                            string deleteQuery = "DELETE FROM booking WHERE nim = @nim";
                            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, koneksi);
                            deleteCommand.Parameters.AddWithValue("@nim", txtNIM.Text);
                            deleteCommand.ExecuteNonQuery();
                            MessageBox.Show("Student berhasil ditambah!");

                            // Reload data
                            FrmTambahDormKid_Load(null, null);

                            // Bersihkan input
                            txtNIM.Text = "";
                            txtNamaMahasiswa.Text = "";
                            txtKamar.Text = "";
                            txtAsrama.Text = "";
                            txtGender.Text = "";

                            txtNIM.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan data.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    koneksi.Close();
                }
            }
            else
            {
                MessageBox.Show("Semua field harus diisi.");
            }
        }
        private void ClearFields()
        {
            txtNIM.Text = "";
            txtNamaMahasiswa.Text = "";
            txtKamar.Text = "";
            txtAsrama.Text = "";
            txtGender.Text = "";
            txtNIM.Enabled = true;
        }
    }
}
