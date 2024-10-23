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

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    ds.Clear();

                    // Query untuk student
                    string queryStudent = string.Format("SELECT * FROM student WHERE email = '{0}'", txtEmail.Text);
                    koneksi.Open();
                    perintah = new MySqlCommand(queryStudent, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // Login sebagai student
                        DataRow kolom = ds.Tables[0].Rows[0];
                        string sandi = kolom["password"].ToString();
                        if (sandi == txtPass.Text)
                        {
                            FrmStudent frmstudent = new FrmStudent();
                            frmstudent.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Password salah untuk Student");
                        }
                    }
                    else
                    {
                        // Query untuk monitor
                        ds.Clear(); // Bersihkan dataset sebelum query berikutnya
                        string queryMonitor = string.Format("SELECT * FROM monitor WHERE email = '{0}'", txtEmail.Text);
                        koneksi.Open();
                        perintah = new MySqlCommand(queryMonitor, koneksi);
                        adapter = new MySqlDataAdapter(perintah);
                        perintah.ExecuteNonQuery();
                        adapter.Fill(ds);
                        koneksi.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // Login sebagai monitor
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
                                MessageBox.Show("Password salah untuk Monitor");
                            }
                        }
                        else
                        {
                            // Query untuk kepala asrama (dormitory_head)
                            ds.Clear(); // Bersihkan dataset sebelum query berikutnya
                            string queryDormitory_Head = string.Format("SELECT * FROM dormitory_head WHERE email = '{0}'", txtEmail.Text);
                            koneksi.Open();
                            perintah = new MySqlCommand(queryDormitory_Head, koneksi);
                            adapter = new MySqlDataAdapter(perintah);
                            perintah.ExecuteNonQuery();
                            adapter.Fill(ds);
                            koneksi.Close();

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                // Login sebagai kepala asrama
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
                                    MessageBox.Show("Password salah untuk Kepala Asrama");
                                }
                            }
                            else
                            {
                                // Jika tidak ada email ditemukan di ketiga tabel
                                MessageBox.Show("Username tidak ditemukan");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
    }
}
