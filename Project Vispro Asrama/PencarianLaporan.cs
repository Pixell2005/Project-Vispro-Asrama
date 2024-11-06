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
    public partial class PencarianLaporan : Form
    {
        public PencarianLaporan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR_Akun1.SetParameterValue("student_asrama", txtUsername.Text);
            crystalReportViewer1.ReportSource = CR_Akun1;
            crystalReportViewer1.Refresh();
        }
    }
}
