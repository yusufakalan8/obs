using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTOMASYONV1
{
    public partial class FRMACILISFORMU : Form
    {
        public FRMACILISFORMU()
        {
            InitializeComponent();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           
            button1.BackColor = Color.FromArgb(206, 184, 21);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(17, 29, 44);

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.FromArgb(247, 0, 0);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.FromArgb(5, 101, 220);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frmac = new Form1();
            frmac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YonetimPaneli.FrmAkademiGiris frmac = new YonetimPaneli.FrmAkademiGiris();
            frmac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yetkili.FrmYetgiliGiris frmac = new Yetkili.FrmYetgiliGiris();
            frmac.Show();
            this.Hide();
        }

        private void FRMACILISFORMU_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_Tarih.Text = DateTime.Now.ToLongDateString();
            Lbl_Saat.Text = DateTime.Now.ToLongTimeString();
        }

        private void FRMACILISFORMU_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
}
