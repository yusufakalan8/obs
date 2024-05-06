namespace OTOMASYONV1.Yetkili
{
    partial class FrmOgrenciDuyuruEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOgrenciDuyuruEkle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_CikisYap = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RichDuyrular = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.panel1.Controls.Add(this.Btn_CikisYap);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 40);
            this.panel1.TabIndex = 4;
            // 
            // Btn_CikisYap
            // 
            this.Btn_CikisYap.BackColor = System.Drawing.Color.Crimson;
            this.Btn_CikisYap.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_CikisYap.FlatAppearance.BorderSize = 0;
            this.Btn_CikisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_CikisYap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Btn_CikisYap.Location = new System.Drawing.Point(329, 0);
            this.Btn_CikisYap.Name = "Btn_CikisYap";
            this.Btn_CikisYap.Size = new System.Drawing.Size(40, 40);
            this.Btn_CikisYap.TabIndex = 0;
            this.Btn_CikisYap.Text = "X";
            this.Btn_CikisYap.UseVisualStyleBackColor = false;
            this.Btn_CikisYap.Click += new System.EventHandler(this.Btn_CikisYap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::OTOMASYONV1.Properties.Resources.PlusWhite;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(37, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "DUYURU EKLEME EKRANI";
            // 
            // RichDuyrular
            // 
            this.RichDuyrular.Location = new System.Drawing.Point(16, 32);
            this.RichDuyrular.Name = "RichDuyrular";
            this.RichDuyrular.Size = new System.Drawing.Size(297, 273);
            this.RichDuyrular.TabIndex = 5;
            this.RichDuyrular.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.RichDuyrular);
            this.groupBox1.Location = new System.Drawing.Point(21, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 446);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DUYURU";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(16, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(297, 54);
            this.button2.TabIndex = 6;
            this.button2.Text = "DUYURULAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(16, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 54);
            this.button1.TabIndex = 6;
            this.button1.Text = "OLUŞTUR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // FrmOgrenciDuyuruEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 515);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(280, 160);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmOgrenciDuyuruEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmDuyuruEkle";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDuyuruEkle_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_CikisYap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RichDuyrular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}