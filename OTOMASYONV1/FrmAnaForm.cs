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
using OTOMASYONV1.YonetimPaneli;

namespace OTOMASYONV1
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            FRMACILISFORMU frm = new FRMACILISFORMU();
            this.Close();
            frm.Show();
            
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                // pictureBox2.BackColor = Color.SteelBlue;
                pictureBox2.Image = Properties.Resources.AboutGreen;
                panel4.Visible = false;
            }
            else if (panel4.Visible == false)
            {
               // pictureBox2.BackColor = Color.DimGray;
                panel4.Visible = true;
                pictureBox2.Image = Properties.Resources.AboutWhite;
            }
        }
        public string OGRADI, OGRSOYADI, OGRNO, OGRBOLUM,OGRFAKULTE;
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            UniBilgi();
            panel4.Visible = true;
            pictureBox2.Image = Properties.Resources.AboutGreen;
            label2.Text = OGRADI + " " + OGRSOYADI;
            label3.Text = OGRNO;
            bilgigetir();
            OGRBOLUM = label5.Text;
            

        }
        void UniBilgi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Uninfo", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                s1.Text = oku["UNIREKTOR"].ToString();
                s2.Text = oku["UNIOGRSAY"].ToString();
                s3.Text = oku["UNIESAY"].ToString();
                s4.Text = oku["UNIFAKSAY"].ToString();
                s5.Text = oku["UNIBOLSAY"].ToString();
            }
            baglanti.Close();
        }
        void bilgigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_OgrenciDetay where OGRNO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", OGRNO);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                label4.Text = oku["OGRSINIF"].ToString() + ". SINIF";
                label5.Text = oku["OGRBOLUM"].ToString();
                label6.Text = oku["OGRFAKULTE"].ToString();

                
                pictureBox3.ImageLocation = oku["OGRESIM"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            FrmDersler d = new FrmDersler();
            d.DERSBOLUM = OGRBOLUM;
            d.ShowDialog(); 
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(82, 182, 98);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
           // button2.BackColor = Color.FromArgb(82, 182, 98);
            button2.BackColor = Color.FromArgb(5, 101, 220);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutGreen;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (panel4.Visible==false)
            {
                pictureBox2.Image = Properties.Resources.AboutWhite;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.AboutGreen;
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            FrmDersSecme d = new FrmDersSecme(); 
            d.DERSBOLUM = OGRBOLUM;
            d.OGRNO = OGRNO;
            d.ShowDialog(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            FrmSecilenDersListesi d = new FrmSecilenDersListesi();
            d.DERSBOLUM = OGRBOLUM;
            d.OGRNO = OGRNO;
            d.ShowDialog(); 
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            //button3.BackColor = Color.FromArgb(82, 182, 98);
            button3.BackColor = Color.FromArgb(151, 0, 166);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(17, 29, 44);
        }

        

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.FromArgb(206, 184, 21);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            FrmNotListesi d = new FrmNotListesi();
            d.DERSBOLUM = OGRBOLUM;
            d.OGRNO = OGRNO;
            d.ShowDialog(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            FrmDevamsizlik d = new FrmDevamsizlik();
            d.DERSBOLUM = OGRBOLUM;
            d.OGRNO = OGRNO;
            d.ShowDialog(); 
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.FromArgb(247, 0, 0);

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void FrmAnaForm_Activated(object sender, EventArgs e)
        {
            bilgigetir();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            Yetkili.FrmOgrenciDuyurular frm = new Yetkili.FrmOgrenciDuyurular();
            frm.ShowDialog();
        }

        private void button8_MouseMove(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.Orange;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            Form1 frm = new Form1();
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Çıkış yapmak istiyor musun ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secim == DialogResult.Yes)
            {
                frm.Show();
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;

            FrmOgrenciBilgiGuncelle d = new FrmOgrenciBilgiGuncelle();
            d.OGRNO = OGRNO;
            d.ShowDialog(); 
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.FromArgb(237, 20, 108);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(17, 29, 44);
        }

    }
}