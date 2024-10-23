namespace Project_Vispro_Asrama
{
    partial class FrmPemeriksaan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoKamar = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTanggalPemeriksaan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJam = new System.Windows.Forms.TextBox();
            this.txtHadir = new System.Windows.Forms.TextBox();
            this.txtTidakHadir = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1031, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "No.Kamar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNoKamar
            // 
            this.txtNoKamar.Location = new System.Drawing.Point(1207, 296);
            this.txtNoKamar.Name = "txtNoKamar";
            this.txtNoKamar.Size = new System.Drawing.Size(269, 22);
            this.txtNoKamar.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(1249, 496);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(162, 54);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(951, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jumlah Mahasiswa Hadir";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTanggalPemeriksaan
            // 
            this.lblTanggalPemeriksaan.AutoSize = true;
            this.lblTanggalPemeriksaan.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalPemeriksaan.Location = new System.Drawing.Point(859, 195);
            this.lblTanggalPemeriksaan.Name = "lblTanggalPemeriksaan";
            this.lblTanggalPemeriksaan.Size = new System.Drawing.Size(379, 69);
            this.lblTanggalPemeriksaan.TabIndex = 4;
            this.lblTanggalPemeriksaan.Text = "Pemeriksaan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(982, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Jam Pemeriksaan";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(913, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Jumlah Mahasiswa Tidak Hadir";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtJam
            // 
            this.txtJam.Location = new System.Drawing.Point(1207, 442);
            this.txtJam.Name = "txtJam";
            this.txtJam.Size = new System.Drawing.Size(269, 22);
            this.txtJam.TabIndex = 7;
            // 
            // txtHadir
            // 
            this.txtHadir.Location = new System.Drawing.Point(1207, 390);
            this.txtHadir.Name = "txtHadir";
            this.txtHadir.Size = new System.Drawing.Size(269, 22);
            this.txtHadir.TabIndex = 8;
            // 
            // txtTidakHadir
            // 
            this.txtTidakHadir.Location = new System.Drawing.Point(1207, 345);
            this.txtTidakHadir.Name = "txtTidakHadir";
            this.txtTidakHadir.Size = new System.Drawing.Size(269, 22);
            this.txtTidakHadir.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 46);
            this.button3.TabIndex = 10;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmPemeriksaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 744);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtTidakHadir);
            this.Controls.Add(this.txtHadir);
            this.Controls.Add(this.txtJam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTanggalPemeriksaan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNoKamar);
            this.Controls.Add(this.label1);
            this.Name = "FrmPemeriksaan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPemeriksaan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPemeriksaan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoKamar;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTanggalPemeriksaan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJam;
        private System.Windows.Forms.TextBox txtHadir;
        private System.Windows.Forms.TextBox txtTidakHadir;
        private System.Windows.Forms.Button button3;
    }
}