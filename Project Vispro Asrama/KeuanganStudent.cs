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
    public partial class KeuanganStudent : Form
    {
        public KeuanganStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Keuangan1.SetParameterValue("data_uang", txtNIM.Text);
            crystalReportViewer1.ReportSource = Keuangan1;
            crystalReportViewer1.Refresh();
        }
    }
}
