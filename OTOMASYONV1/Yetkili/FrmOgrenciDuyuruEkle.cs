using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OTOMASYONV1.Yetkili
{
    public partial class FrmOgrenciDuyuruEkle : Form
    {
        public FrmOgrenciDuyuruEkle()
        {
            InitializeComponent();
        }

        void duyuruOlustur()
        {
            if (RichDuyrular.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_OgrenciDuyurular (DUYURU) values (@p1)", baglanti);
                komut.Parameters.AddWithValue("@p1", RichDuyrular.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Duyuru oluşturuldu.");
                RichDuyrular.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen oluşturulacak duyuruyu girin");
            }
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Green;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            duyuruOlustur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yetkili.FrmOgrenciDuyurular frm = new FrmOgrenciDuyurular();
            frm.ShowDialog();
        }

        private void FrmDuyuruEkle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
}
