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
    public partial class FrmPrameterLaporan : Form
    {
        public FrmPrameterLaporan()
        {
            InitializeComponent();
        }

        private void FrmPrameterLaporan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKepas frmKepas = new FrmKepas();
            frmKepas.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmKepas frmKepas = new FrmKepas();
            frmKepas.Show();
            this.Hide();
        }
    }
}
