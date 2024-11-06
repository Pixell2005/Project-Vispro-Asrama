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
        private Form activeMenuForm = null;
        public FrmKepas()
        {
            InitializeComponent();
        }

        private void OpenMenuForm(Form menuForm)
        {
            // Close the currently active menu form, if any
            if (activeMenuForm != null)
            {
                activeMenuForm.Close();
            }

            // Set the new form as the active form and show it
            activeMenuForm = menuForm;
            activeMenuForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No) return;

            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }

        private void FrmKepas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmTambahDormKid = new FrmTambahDormKid();
            ShowFormInPanel(frmTambahDormKid);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void btnData_Click(object sender, EventArgs e)
        {
            var semuaStudent = new SemuaStudent();
            ShowFormInPanel(semuaStudent);
        }

        private void btnKeuangan_Click(object sender, EventArgs e)
        {
            var keuanganStudent = new KeuanganStudent();
            ShowFormInPanel(keuanganStudent);
        }

        private void btnCariStudent_Click(object sender, EventArgs e)
        {
            var pencarianLaporan = new PencarianLaporan();
            ShowFormInPanel(pencarianLaporan);
        }

        private void btnDropStudent_Click(object sender, EventArgs e)
        {
            var frmDropStudent = new FrmDropStudent();
            ShowFormInPanel(frmDropStudent);
        }
    }
}
