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
    public partial class FrmMain : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;

        public FrmMain()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmInfoAsrama frmInfoAsrama = new FrmInfoAsrama();
            frmInfoAsrama.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Clear();

                // Query untuk student_asrama dengan NULL handling
                string queryStudent = @"SELECT NIM, full_name, sisa_bayar, password, room_number,
                                NULLIF(check_in, '0000-00-00 00:00:00') AS check_in, 
                                NULLIF(check_out, '0000-00-00 00:00:00') AS check_out
                                FROM student_asrama 
                                WHERE email = @Email";

                koneksi.Open();
                perintah = new MySqlCommand(queryStudent, koneksi);
                perintah.Parameters.AddWithValue("@Email", txtEmail.Text);
                adapter = new MySqlDataAdapter(perintah);
                adapter.Fill(ds);
                koneksi.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Login sebagai student_asrama
                    DataRow kolom = ds.Tables[0].Rows[0];
                    string sandi = kolom["password"].ToString();

                    // Compare password
                    if (sandi == txtPass.Text)
                    {
                        // Get user details
                        string namaPengguna = kolom["full_name"].ToString();
                        string nim = kolom["NIM"].ToString();
                        decimal sisaBayar = Convert.ToDecimal(kolom["sisa_bayar"]);
                        string noKamar = kolom["room_number"].ToString();

                        // Parse check_in date safely
                        DateTime? checkInDate = null;
                        if (kolom["check_in"] != DBNull.Value)
                        {
                            if (DateTime.TryParse(kolom["check_in"].ToString(), out DateTime parsedCheckIn))
                            {
                                checkInDate = parsedCheckIn;
                            }
                        }

                        // Parse check_out date safely
                        DateTime? checkOutDate = null;
                        if (kolom["check_out"] != DBNull.Value)
                        {
                            if (DateTime.TryParse(kolom["check_out"].ToString(), out DateTime parsedCheckOut))
                            {
                                checkOutDate = parsedCheckOut;
                            }
                        }

                        // Open the student form and pass necessary details
                        FrmStudent frmStudent = new FrmStudent(namaPengguna, nim, sisaBayar, noKamar);
                        frmStudent.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password salah untuk Student");
                    }
                }
                else
                {
                    // Query for monitor
                    ds.Clear();
                    string queryMonitor = "SELECT * FROM monitor WHERE email = @Email";
                    koneksi.Open();
                    perintah = new MySqlCommand(queryMonitor, koneksi);
                    perintah.Parameters.AddWithValue("@Email", txtEmail.Text);
                    adapter = new MySqlDataAdapter(perintah);
                    adapter.Fill(ds);
                    koneksi.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // Login as monitor
                        DataRow kolom = ds.Tables[0].Rows[0];
                        string sandi = kolom["password"].ToString();

                        if (sandi == txtPass.Text)
                        {
                            FrmMntor frmmntor = new FrmMntor();
                            frmmntor.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Password incorrect for Monitor.");
                        }
                    }
                    else
                    {
                        // Query for dormitory_head
                        ds.Clear();
                        string queryDormitoryHead = "SELECT * FROM dormitory_head WHERE email = @Email";
                        koneksi.Open();
                        perintah = new MySqlCommand(queryDormitoryHead, koneksi);
                        perintah.Parameters.AddWithValue("@Email", txtEmail.Text);
                        adapter = new MySqlDataAdapter(perintah);
                        adapter.Fill(ds);
                        koneksi.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // Login as dormitory head
                            DataRow kolom = ds.Tables[0].Rows[0];
                            string sandi = kolom["password"].ToString();

                            if (sandi == txtPass.Text)
                            {
                                FrmKepas frmkepas = new FrmKepas();
                                frmkepas.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Password incorrect for Dormitory Head.");
                            }
                        }
                        else
                        {
                            // No email found in any of the tables
                            MessageBox.Show("Username not found.");
                        }
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
    }
}
