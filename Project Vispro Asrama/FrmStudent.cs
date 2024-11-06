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
   public partial class FrmStudent : Form
{
    private string namaPengguna;
    private string nim;
    private decimal sisaBayar;
    private string noKamar;

    // Konstruktor baru yang menerima data pengguna
    public FrmStudent(string nama, string nim, decimal sisaBayar, string noKamar)
    {
        InitializeComponent();
        this.namaPengguna = nama;
        this.nim = nim;
        this.sisaBayar = sisaBayar;
        this.noKamar = noKamar;

        // Menampilkan data pengguna
        lblNama.Text = namaPengguna;
        lblNIM.Text = nim;
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
        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No) return;

            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
            this.Hide();

        }
    private void button2_Click(object sender, EventArgs e)
    {
        var frmTransaction = new FrmTransaction(namaPengguna, nim, sisaBayar); 
        ShowFormInPanel(frmTransaction);
    }

        private void button4_Click(object sender, EventArgs e)
        {
            var frmChangePass = new FrmChangePass();
            ShowFormInPanel(frmChangePass);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
