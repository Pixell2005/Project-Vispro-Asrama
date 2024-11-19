namespace Project_Vispro_Asrama
{
    partial class FrmKamar
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
            this.btnCrystal = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEdelweis = new System.Windows.Forms.Button();
            this.btnJasmine = new System.Windows.Forms.Button();
            this.btnAnnex = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrystal
            // 
            this.btnCrystal.Location = new System.Drawing.Point(59, 351);
            this.btnCrystal.Name = "btnCrystal";
            this.btnCrystal.Size = new System.Drawing.Size(92, 35);
            this.btnCrystal.TabIndex = 0;
            this.btnCrystal.Text = "Crystal";
            this.btnCrystal.UseVisualStyleBackColor = true;
            this.btnCrystal.Click += new System.EventHandler(this.btnCrystal_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 392);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(691, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnEdelweis
            // 
            this.btnEdelweis.Location = new System.Drawing.Point(167, 351);
            this.btnEdelweis.Name = "btnEdelweis";
            this.btnEdelweis.Size = new System.Drawing.Size(92, 35);
            this.btnEdelweis.TabIndex = 2;
            this.btnEdelweis.Text = "Edelweis";
            this.btnEdelweis.UseVisualStyleBackColor = true;
            this.btnEdelweis.Click += new System.EventHandler(this.btnEdelweis_Click);
            // 
            // btnJasmine
            // 
            this.btnJasmine.Location = new System.Drawing.Point(280, 351);
            this.btnJasmine.Name = "btnJasmine";
            this.btnJasmine.Size = new System.Drawing.Size(92, 35);
            this.btnJasmine.TabIndex = 3;
            this.btnJasmine.Text = "Jasmine";
            this.btnJasmine.UseVisualStyleBackColor = true;
            this.btnJasmine.Click += new System.EventHandler(this.btnJasmine_Click);
            // 
            // btnAnnex
            // 
            this.btnAnnex.Location = new System.Drawing.Point(393, 351);
            this.btnAnnex.Name = "btnAnnex";
            this.btnAnnex.Size = new System.Drawing.Size(92, 35);
            this.btnAnnex.TabIndex = 4;
            this.btnAnnex.Text = "Annex";
            this.btnAnnex.UseVisualStyleBackColor = true;
            this.btnAnnex.Click += new System.EventHandler(this.btnAnnex_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 35);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "< Register";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmKamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project_Vispro_Asrama.Properties.Resources._088154ee_ea75_4205_a165_94cf32fb3b0c;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(981, 549);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAnnex);
            this.Controls.Add(this.btnJasmine);
            this.Controls.Add(this.btnEdelweis);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCrystal);
            this.Name = "FrmKamar";
            this.Text = "FrmKamar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrystal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEdelweis;
        private System.Windows.Forms.Button btnJasmine;
        private System.Windows.Forms.Button btnAnnex;
        private System.Windows.Forms.Button btnBack;
    }
}