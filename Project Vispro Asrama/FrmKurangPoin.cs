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
    public partial class FrmKurangPoin : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FrmKurangPoin()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan field NIM, Nama Mahasiswa, No Kamar, dan Poin terisi
                if (txtNIM.Text != "" && txtNamaMahasiswa.Text != "" && txtPoin.Text != "" && txtKamar.Text != "")
                {
                    // Query untuk cek apakah NIM sudah ada di database student_asrama
                    string queryStudentAsrama = string.Format("SELECT poin FROM student_asrama WHERE nim = '{0}'", txtNIM.Text);

                    koneksi.Open();
                    MySqlCommand perintah = new MySqlCommand(queryStudentAsrama, koneksi);
                    MySqlDataReader reader = perintah.ExecuteReader();

                    if (reader.Read())
                    {
                        // Jika mahasiswa ditemukan berdasarkan NIM, tambahkan poin baru ke poin yang sudah ada
                        int currentPoin = Convert.ToInt32(reader["poin"]);
                        int additionalPoin = Convert.ToInt32(txtPoin.Text);
                        int newTotalPoin = currentPoin - additionalPoin;

                        // Tutup reader sebelum menjalankan query update
                        reader.Close();

                        // Update poin di tabel student_asrama berdasarkan NIM
                        queryStudentAsrama = string.Format("UPDATE student_asrama SET poin = {0} WHERE nim = '{1}'", newTotalPoin, txtNIM.Text);

                        MySqlCommand perintahUpdate = new MySqlCommand(queryStudentAsrama, koneksi);
                        int res = perintahUpdate.ExecuteNonQuery();

                        if (res == 1)
                        {
                            MessageBox.Show("Poin berhasil dikurangi. Total Poin: " + newTotalPoin);

                            // Buka FrmBerandaMntor setelah sukses menambahkan poin
                            FrmMntor frmMntor = new FrmMntor();
                            frmMntor.Show();
                            this.Hide(); // Sembunyikan form saat ini
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengurangi poin.");
                        }
                    }

                    koneksi.Close();
                }
                else
                {
                    MessageBox.Show("NIM, Nama mahasiswa, No Kamar, dan poin harus diisi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                koneksi.Close();
            }

        }

        private void FrmKurangPoin_Load(object sender, EventArgs e)
        {

        }
    }
}
