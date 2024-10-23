using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Vispro_Asrama
{
    public partial class FrmMntor : Form
    {
        public FrmMntor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmJadwalPemeriksaan frmJadwalPemeriksaan = new FrmJadwalPemeriksaan();
            frmJadwalPemeriksaan.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPoin frmPoin = new FrmPoin();
            frmPoin.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }
    }
}
