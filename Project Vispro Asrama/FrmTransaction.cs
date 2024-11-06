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
    public partial class FrmTransaction : Form
    {

        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public void FrmTransaction_Load(object sender, EventArgs e)
        {
            // Kode yang seharusnya dijalankan ketika form dimuat
            // ...
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string queryStudent = "SELECT * FROM student_asrama";
            koneksi.Open();
            perintah = new MySqlCommand(queryStudent, koneksi);
            MySqlDataReader reader = perintah.ExecuteReader();

            if (reader.Read())
            {
                string namaPengguna = reader["full_name"].ToString();
                string nim = reader["NIM"].ToString();
                decimal sisaBayar = Convert.ToDecimal(reader["sisa_bayar"]);
                string noKamar = reader["room_number"].ToString();

                FrmStudent frmStudent = new FrmStudent(namaPengguna, nim, sisaBayar, noKamar);
                frmStudent.Show();
                this.Close();
            }

            reader.Close();
            koneksi.Close();

        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan field NIM dan Uang terisi
                if (!string.IsNullOrEmpty(txtNIM.Text) && !string.IsNullOrEmpty(txtUang.Text))
                {
                    // Query untuk cek apakah NIM sudah ada di database student_asrama
                    string queryStudentAsrama = string.Format("SELECT full_name, NIM, sisa_bayar, room_number FROM student_asrama WHERE nim = '{0}'", txtNIM.Text);
                    koneksi.Open();

                    MySqlCommand perintah = new MySqlCommand(queryStudentAsrama, koneksi);
                    MySqlDataReader reader = perintah.ExecuteReader();

                    if (reader.Read())
                    {
                        // Dapatkan data pengguna sebelum menutup reader
                        string namaPengguna = reader["full_name"].ToString();
                        string nim = reader["NIM"].ToString();
                        decimal currentPay = Convert.ToDecimal(reader["sisa_bayar"]);
                        decimal additionalPay = Convert.ToDecimal(txtUang.Text);
                        string noKamar = reader["room_number"].ToString();

                        // Cek apakah pembayaran akan menghasilkan saldo negatif
                        if (additionalPay > currentPay)
                        {
                            MessageBox.Show("Pembayaran melebihi sisa bayar. Harap masukkan jumlah yang sesuai.");
                            reader.Close();
                            koneksi.Close();
                            return;
                        }

                        decimal newTotalPay = currentPay - additionalPay;

                        // Tutup reader sebelum menjalankan query update
                        reader.Close();

                        // Update nilai sisa_bayar di tabel student_asrama berdasarkan NIM
                        string queryUpdate = string.Format("UPDATE student_asrama SET sisa_bayar = {0}, terbayar = {1} WHERE nim = '{2}'", newTotalPay, additionalPay, txtNIM.Text);
                        MySqlCommand perintahUpdate = new MySqlCommand(queryUpdate, koneksi);
                        int res = perintahUpdate.ExecuteNonQuery();

                        if (res == 1)
                        {
                            MessageBox.Show("Pembayaran berhasil. Last Balance: " + newTotalPay);

                            // Perbarui informasi pengguna
                            lblLastBalance.Text = newTotalPay.ToString("C");
                            txtBalance.Text = newTotalPay.ToString();

                            // Buka form FrmStudent dengan nilai yang diperbarui
                            FrmStudent frmStudent = new FrmStudent(namaPengguna, nim, newTotalPay, noKamar);
                            frmStudent.Show();
                            this.Close(); // Tutup form saat ini jika diperlukan
                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui sisa bayar.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("NIM tidak ditemukan.");
                    }

                    koneksi.Close();
                }
                else
                {
                    MessageBox.Show("Harap isi NIM dan Jumlah Uang.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                koneksi.Close();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            lblFoto.Visible = false;
        }

        public FrmTransaction(string nama, string nim, decimal sisa_bayar)
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();

            // Tampilkan data pengguna di label atau textbox
            txtNIM.Text = nim;
            txtNama.Text = nama;
            txtBalance.Text = sisa_bayar.ToString();
            lblNama.Text = nama;
            lblNIM.Text = nim;
            lblLastBalance.Text = sisa_bayar.ToString("C");
        }
    }

}
