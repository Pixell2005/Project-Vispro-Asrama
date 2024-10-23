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
    public partial class FrmKepas : Form
    {
        public FrmKepas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPrameterLaporan frmPrameterLaporan = new FrmPrameterLaporan();
            frmPrameterLaporan.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }

        private void FrmKepas_Load(object sender, EventArgs e)
        {

        }
    }
}
