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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoKamar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJam = new System.Windows.Forms.TextBox();
            this.txtHadir = new System.Windows.Forms.TextBox();
            this.txtTidakHadir = new System.Windows.Forms.TextBox();
            this.lblTanggalPemeriksaan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(809, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "No.Kamar";
            // 
            // txtNoKamar
            // 
            this.txtNoKamar.Location = new System.Drawing.Point(772, 274);
            this.txtNoKamar.Name = "txtNoKamar";
            this.txtNoKamar.Size = new System.Drawing.Size(269, 22);
            this.txtNoKamar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jumlah tidak di kamar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(469, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jumlah ada di kamar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(508, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jam pemeriksaan";
            // 
            // txtJam
            // 
            this.txtJam.Location = new System.Drawing.Point(772, 427);
            this.txtJam.Name = "txtJam";
            this.txtJam.Size = new System.Drawing.Size(269, 22);
            this.txtJam.TabIndex = 8;
            // 
            // txtHadir
            // 
            this.txtHadir.Location = new System.Drawing.Point(772, 375);
            this.txtHadir.Name = "txtHadir";
            this.txtHadir.Size = new System.Drawing.Size(269, 22);
            this.txtHadir.TabIndex = 9;
            // 
            // txtTidakHadir
            // 
            this.txtTidakHadir.Location = new System.Drawing.Point(772, 324);
            this.txtTidakHadir.Name = "txtTidakHadir";
            this.txtTidakHadir.Size = new System.Drawing.Size(269, 22);
            this.txtTidakHadir.TabIndex = 10;
            // 
            // lblTanggalPemeriksaan
            // 
            this.lblTanggalPemeriksaan.AutoSize = true;
            this.lblTanggalPemeriksaan.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggalPemeriksaan.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalPemeriksaan.Location = new System.Drawing.Point(511, 181);
            this.lblTanggalPemeriksaan.Name = "lblTanggalPemeriksaan";
            this.lblTanggalPemeriksaan.Size = new System.Drawing.Size(234, 54);
            this.lblTanggalPemeriksaan.TabIndex = 11;
            this.lblTanggalPemeriksaan.Text = "No.Kamar";
            this.lblTanggalPemeriksaan.Click += new System.EventHandler(this.label5_Click);
            // 
            // FrmPemeriksaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project_Vispro_Asrama.Properties.Resources._088154ee_ea75_4205_a165_94cf32fb3b0c;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1271, 717);
            this.Controls.Add(this.lblTanggalPemeriksaan);
            this.Controls.Add(this.txtTidakHadir);
            this.Controls.Add(this.txtHadir);
            this.Controls.Add(this.txtJam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoKamar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPemeriksaan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPemeriksaan";
            this.Load += new System.EventHandler(this.FrmPemeriksaan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoKamar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJam;
        private System.Windows.Forms.TextBox txtHadir;
        private System.Windows.Forms.TextBox txtTidakHadir;
        private System.Windows.Forms.Label lblTanggalPemeriksaan;
    }
}