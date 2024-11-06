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
    public partial class FrmChangePass : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FrmChangePass()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNew.Text))
                {
                    string email = txtEmail.Text;
                    string passwordLama = txtPass.Text;
                    string passwordBaru = txtNew.Text;

                    // Buka koneksi ke database
                    koneksi.Open();

                    // Cek apakah email dan password lama cocok dengan yang ada di database
                    string cekQuery = "SELECT COUNT(*) FROM student_asrama WHERE email = @Email AND password = @PasswordLama";
                    MySqlCommand cekPerintah = new MySqlCommand(cekQuery, koneksi);
                    cekPerintah.Parameters.AddWithValue("@Email", email);
                    cekPerintah.Parameters.AddWithValue("@PasswordLama", passwordLama);

                    int count = Convert.ToInt32(cekPerintah.ExecuteScalar());

                    if (count > 0)
                    {
                        // Jika email dan password lama valid, update password baru
                        string updateQuery = "UPDATE student_asrama SET password = @PasswordBaru WHERE email = @Email";
                        MySqlCommand updatePerintah = new MySqlCommand(updateQuery, koneksi);
                        updatePerintah.Parameters.AddWithValue("@PasswordBaru", passwordBaru);
                        updatePerintah.Parameters.AddWithValue("@Email", email);

                        int result = updatePerintah.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Password berhasil diperbarui.");

                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui password. Silakan coba lagi.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email atau password lama tidak cocok.");
                    }

                    // Tutup koneksi
                    koneksi.Close();
                }
                else
                {
                    MessageBox.Show("Semua field harus diisi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                koneksi.Close();
            }

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
    }
}
