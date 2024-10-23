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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMntor frmMntor = new FrmMntor();
            frmMntor.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ambil tanggal yang dipilih dari MonthCalendar
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            // Buat instance FrmPemeriksaan dengan parameter tanggal
            FrmPemeriksaan frmPemeriksaan = new FrmPemeriksaan(selectedDate);

            // Tampilkan FrmPemeriksaan
            frmPemeriksaan.Show();

            // Sembunyikan form Jadwal Pemeriksaan ini
            this.Hide();

        }
    }
}
