﻿using MySql.Data.MySqlClient;
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
    public partial class FrmPemeriksaan : Form
    {

        private MySqlConnection koneksi;
        private MySqlCommand perintah;
        private string alamat;
        private DateTime selectedDate;
        public FrmPemeriksaan(DateTime date)
        {
            // Inisialisasi string koneksi ke database
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();

            // Simpan tanggal yang diterima ke dalam variabel lokal
            selectedDate = date;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNoKamar.Text != "" && txtTidakHadir.Text != "" && txtHadir.Text != "" && txtHadir.Text != "")
            {
                try
                {
                    koneksi.Open();

                    // Query SQL untuk memasukkan data pemeriksaan
                    string query = "INSERT INTO pemeriksaan (tanggal_pemeriksaan, no_kamar, jumlah_tidak_hadir, jumlah_hadir, jam_pemeriksaan) " +
                                   "VALUES (@tanggal, @noKamar, @tidakHadir, @hadir, @jam)";
                    perintah = new MySqlCommand(query, koneksi);
                    perintah.Parameters.AddWithValue("@tanggal", selectedDate);
                    perintah.Parameters.AddWithValue("@noKamar", txtNoKamar.Text);
                    perintah.Parameters.AddWithValue("@tidakHadir", Convert.ToInt32(txtTidakHadir.Text));
                    perintah.Parameters.AddWithValue("@hadir", Convert.ToInt32(txtHadir.Text));
                    perintah.Parameters.AddWithValue("@jam", txtHadir.Text);

                    int res = perintah.ExecuteNonQuery();

                    if (res == 1)
                    {
                        MessageBox.Show("Data pemeriksaan berhasil disimpan!");
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data.");
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

                // Setelah data tersimpan, kembali ke BerandaMntor
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Semua field harus diisi.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmJadwalPemeriksaan frmJadwalPemeriksaan = new FrmJadwalPemeriksaan();
            frmJadwalPemeriksaan.Show();
            this.Hide();
        }

        private void FrmPemeriksaan_Load(object sender, EventArgs e)
        {
            if (lblTanggalPemeriksaan != null)
            {
                lblTanggalPemeriksaan.Text = "Tanggal Pemeriksaan: " + selectedDate.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Label tanggal tidak ditemukan!");
            }
        }
    }
}
