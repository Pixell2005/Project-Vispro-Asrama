using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class FrmDropStudent : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FrmDropStudent()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNIM.Text))
                {
                    MessageBox.Show("Data Siswa Yang Anda Cari Tidak Terdaftar!");
                    return;
                }

                // Query untuk mencari data berdasarkan NIM dengan kolom yang diperlukan
                query = @"SELECT NIM, full_name AS nama, room_number AS kamar, 
                                 NULLIF(check_in, '0000-00-00 00:00:00') AS check_in, 
                                 sisa_bayar, poin, asrama
                          FROM student_asrama 
                          WHERE NIM = @nim";

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
                    // Display data in text fields
                    var kolom = ds.Tables[0].Rows[0];
                    txtNIM.Text = kolom["NIM"].ToString();
                    txtNamaMahasiswa.Text = kolom["nama"].ToString();
                    txtAsrama.Text = kolom["asrama"].ToString();
                    txtKamar.Text = kolom["kamar"].ToString();
                    txtCheckIn.Text = kolom["check_in"] == DBNull.Value ? "" : Convert.ToDateTime(kolom["check_in"]).ToString("yyyy-MM-dd HH:mm:ss");
                    txtBalance.Text = kolom["sisa_bayar"].ToString();
                    txtPoin.Text = kolom["poin"].ToString();

                    // Display data in DataGridView
                    dataGridViewStudents.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Data Siswa Tidak Terdaftar!");
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

        private void DeleteStudentData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNIM.Text))
                {
                    MessageBox.Show("Silakan masukkan NIM siswa yang ingin dihapus.");
                    return;
                }

                // Konfirmasi penghapusan data
                var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.No) return;

                query = "DELETE FROM student_asrama WHERE NIM = @nim";

                if (koneksi.State == ConnectionState.Closed)
                {
                    koneksi.Open();
                }

                using (var perintah = new MySqlCommand(query, koneksi))
                {
                    perintah.Parameters.AddWithValue("@nim", txtNIM.Text);
                    int rowsAffected = perintah.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus.");
                        ClearForm();
                        // Clear the DataGridView after deletion
                        dataGridViewStudents.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau gagal dihapus.");
                    }
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

        private void ClearForm()
        {
            txtNIM.Clear();
            txtNamaMahasiswa.Clear();
            txtAsrama.Clear();
            txtKamar.Clear();
            txtBalance.Clear();
            txtPoin.Clear();
            txtCheckIn.Clear();
        }

        private void FrmDropStudent_Load(object sender, EventArgs e)
        {
            LoadAllStudents(); // Load all students data on form load
            ClearForm();       // Clear the form fields
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            DeleteStudentData();
        }

        // Method to load all students into DataGridView
        private void LoadAllStudents()
        {
            try
            {
                ds.Clear(); // Clear existing data

                if (koneksi.State == ConnectionState.Closed)
                {
                    koneksi.Open();
                }

                query = "SELECT NIM, full_name AS Nama, room_number AS Kamar, asrama AS Asrama, sisa_bayar AS Balance, poin AS Poin, NULLIF(check_in, '0000-00-00 00:00:00') AS Check_in FROM student_asrama";

                using (var perintah = new MySqlCommand(query, koneksi))
                using (var adapter = new MySqlDataAdapter(perintah))
                {
                    adapter.Fill(ds);
                    dataGridViewStudents.DataSource = ds.Tables[0]; // Bind dataset to DataGridView
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
    }
}
