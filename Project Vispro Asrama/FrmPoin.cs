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
    public partial class FrmPoin : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public FrmPoin()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmPoin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMntor frmMntor = new FrmMntor();
            frmMntor.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan field NIM, Nama Mahasiswa, No Kamar, dan Poin terisi
                if (txtNIM.Text != "" && txtNamaMahasiswa.Text != "" && txtPoin.Text != "" && txtKamar.Text != "")
                {
                    // Query untuk cek apakah NIM sudah ada di database
                    query = string.Format("SELECT poin FROM poin_mahasiswa WHERE nim = '{0}'", txtNIM.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    MySqlDataReader reader = perintah.ExecuteReader();

                    if (reader.Read())
                    {
                        // Jika mahasiswa ditemukan berdasarkan NIM, tambahkan poin baru ke poin yang sudah ada
                        int currentPoin = Convert.ToInt32(reader["poin"]);
                        int additionalPoin = Convert.ToInt32(txtPoin.Text);
                        int newTotalPoin = currentPoin + additionalPoin;

                        // Tutup reader sebelum menjalankan query update
                        reader.Close();

                        // Update poin di database berdasarkan NIM
                        query = string.Format("UPDATE poin_mahasiswa SET poin = {0} WHERE nim = '{1}'", newTotalPoin, txtNIM.Text);
                        perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery();

                        if (res == 1)
                        {
                            MessageBox.Show("Poin berhasil ditambahkan. Total Poin: " + newTotalPoin);

                            // Buka FrmBerandaMntor setelah sukses menambahkan poin
                            FrmMntor frmMntor = new FrmMntor();
                            frmMntor.Show();
                            this.Hide(); // Sembunyikan form saat ini
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan poin.");
                        }
                    }
                    else
                    {
                        // Jika mahasiswa dengan NIM tersebut tidak ditemukan, tambahkan sebagai mahasiswa baru
                        reader.Close(); // Tutup reader sebelum melakukan operasi lain

                        int newPoin = Convert.ToInt32(txtPoin.Text);
                        string jenisPelanggaran = txtJenisPelanggaran.Text; // Ambil jenis pelanggaran dari field input

                        // Query untuk menambahkan mahasiswa baru ke database berdasarkan NIM dan Nama
                        query = string.Format("INSERT INTO poin_mahasiswa (nim, nama_mahasiswa, no_kamar, jumlah_pelanggaran, jenis_pelanggaran, poin) " +
                                              "VALUES ('{0}', '{1}', '{2}', {3}, '{4}', {5})",
                                              txtNIM.Text, txtNamaMahasiswa.Text, txtKamar.Text, 1, jenisPelanggaran, newPoin);

                        perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery();

                        if (res == 1)
                        {
                            MessageBox.Show("Mahasiswa baru berhasil ditambahkan dengan NIM: " + txtNIM.Text + " dan Poin: " + newPoin);

                            // Buka FrmBerandaMntor setelah sukses menambahkan mahasiswa baru
                            FrmMntor frmMntor = new FrmMntor();
                            frmMntor.Show();
                            this.Hide(); // Sembunyikan form saat ini
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan mahasiswa baru.");
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
            }

        }
    }
}
