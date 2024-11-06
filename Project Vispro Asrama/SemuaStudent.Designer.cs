namespace Project_Vispro_Asrama
{
    partial class SemuaStudent
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAllStudent = new System.Windows.Forms.Button();
            this.btnPemeriksaan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 688);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(834, 173);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAllStudent
            // 
            this.btnAllStudent.BackColor = System.Drawing.Color.Lavender;
            this.btnAllStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllStudent.Location = new System.Drawing.Point(34, 643);
            this.btnAllStudent.Name = "btnAllStudent";
            this.btnAllStudent.Size = new System.Drawing.Size(172, 39);
            this.btnAllStudent.TabIndex = 12;
            this.btnAllStudent.Text = ">Semua Student";
            this.btnAllStudent.UseVisualStyleBackColor = false;
            this.btnAllStudent.Click += new System.EventHandler(this.btnAllStudent_Click);
            // 
            // btnPemeriksaan
            // 
            this.btnPemeriksaan.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPemeriksaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPemeriksaan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPemeriksaan.Location = new System.Drawing.Point(302, 643);
            this.btnPemeriksaan.Name = "btnPemeriksaan";
            this.btnPemeriksaan.Size = new System.Drawing.Size(221, 39);
            this.btnPemeriksaan.TabIndex = 13;
            this.btnPemeriksaan.Text = ">Pemeriksaan Kamar";
            this.btnPemeriksaan.UseVisualStyleBackColor = false;
            this.btnPemeriksaan.Click += new System.EventHandler(this.btnPemeriksaan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 69);
            this.label1.TabIndex = 14;
            this.label1.Text = "Kepala Asrama";
            // 
            // SemuaStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = global::Project_Vispro_Asrama.Properties.Resources._088154ee_ea75_4205_a165_94cf32fb3b0c;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1013, 862);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPemeriksaan);
            this.Controls.Add(this.btnAllStudent);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SemuaStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SemuaStudent";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAllStudent;
        private System.Windows.Forms.Button btnPemeriksaan;
        private System.Windows.Forms.Label label1;
    }
}