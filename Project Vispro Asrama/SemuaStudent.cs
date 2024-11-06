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
    public partial class SemuaStudent : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public SemuaStudent()
        {

            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void LoadKamarData()
        {
            try
            {
                if (koneksi.State == ConnectionState.Closed)
                {
                    koneksi.Open();
                }

                query = "SELECT * FROM pemeriksaan";
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

        private void btnAllStudent_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void btnPemeriksaan_Click(object sender, EventArgs e)
        {
            LoadKamarData();
        }

        private void LoadStudentData()
        {
            try
            {
                if (koneksi.State == ConnectionState.Closed)
                {
                    koneksi.Open();
                }

                // Modifikasi query untuk menangani nilai '0000-00-00 00:00:00' di kolom check_in dan check_out
                query = @"
                    SELECT 
                        NIM, 
                        full_name, 
                        room_number, 
                        IF(check_in = '0000-00-00 00:00:00', NULL, check_in) AS check_in,
                        IF(check_out = '0000-00-00 00:00:00', NULL, check_out) AS check_out,
                        jumlah_pelanggaran, 
                        jenis_pelanggaran, 
                        poin, 
                        email, 
                        password, 
                        terbayar, 
                        sisa_bayar, 
                        foto 
                    FROM student_asrama";

                adapter = new MySqlDataAdapter(query, koneksi);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Konversi kolom tanggal jika diperlukan
                foreach (DataRow row in dt.Rows)
                {
                    // Konversi check_in
                    if (DateTime.TryParse(row["check_in"].ToString(), out DateTime checkInValue))
                    {
                        row["check_in"] = checkInValue;
                    }
                    else
                    {
                        row["check_in"] = DBNull.Value;
                    }

                    // Konversi check_out
                    if (DateTime.TryParse(row["check_out"].ToString(), out DateTime checkOutValue))
                    {
                        row["check_out"] = checkOutValue;
                    }
                    else
                    {
                        row["check_out"] = DBNull.Value;
                    }
                }

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
    }
}
