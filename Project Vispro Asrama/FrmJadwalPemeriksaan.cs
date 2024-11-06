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
    public partial class FrmJadwalPemeriksaan : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;


        public FrmJadwalPemeriksaan()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void ShowFormInPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelKonten.Controls.Clear();  // Bersihkan panel sebelum menambahkan form baru
            panelKonten.Controls.Add(form);
            form.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            // Ambil tanggal yang dipilih dari MonthCalendar
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            // Buat instance FrmPemeriksaan dengan parameter tanggal
            var frmPemeriksaan = new FrmPemeriksaan(selectedDate);

            // Tampilkan FrmPemeriksaan
            ShowFormInPanel(frmPemeriksaan);
        }
    }
}
