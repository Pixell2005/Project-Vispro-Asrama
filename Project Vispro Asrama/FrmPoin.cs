﻿using System;
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
                        int newTotalPoin = currentPoin + additionalPoin;

                        // Tutup reader sebelum menjalankan query update
                        reader.Close();

                        // Update poin di tabel student_asrama berdasarkan NIM
                        queryStudentAsrama = string.Format("UPDATE student_asrama SET poin = {0} WHERE nim = '{1}'", newTotalPoin, txtNIM.Text);

                        MySqlCommand perintahUpdate = new MySqlCommand(queryStudentAsrama, koneksi);
                        int res = perintahUpdate.ExecuteNonQuery();

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

                        // Query untuk menambahkan mahasiswa baru ke tabel student_asrama
                        queryStudentAsrama = string.Format("INSERT INTO student_asrama (nim, full_name, room_number, jumlah_pelanggaran, jenis_pelanggaran, poin) " +
                                                           "VALUES ('{0}', '{1}', '{2}', {3}, '{4}', {5})",
                                                           txtNIM.Text, txtNamaMahasiswa.Text, txtKamar.Text, 1, jenisPelanggaran, newPoin);

                        MySqlCommand perintahInsert = new MySqlCommand(queryStudentAsrama, koneksi);
                        int res = perintahInsert.ExecuteNonQuery();

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
                koneksi.Close();
            }



        }
    }
}
