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
        private Form activeMenuForm = null;
        public FrmMntor()
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

        private void button1_Click(object sender, EventArgs e)
        {
            var frmJadwalPemeriksaan = new FrmJadwalPemeriksaan();
            ShowFormInPanel(frmJadwalPemeriksaan);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmPoin = new FrmPoin();
            ShowFormInPanel(frmPoin);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No) return;

            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frmKurangPoin = new FrmKurangPoin();
            ShowFormInPanel(frmKurangPoin);
        }

        private void FrmMntor_Load(object sender, EventArgs e)
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
    }
}
