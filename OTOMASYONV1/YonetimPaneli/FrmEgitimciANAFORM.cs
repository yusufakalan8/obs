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
namespace OTOMASYONV1.YonetimPaneli
{
    public partial class FrmEgitimciANAFORM : Form
    {
        public FrmEgitimciANAFORM()
        {
            InitializeComponent();
        }

        public string EGINO, EGIAD, EGISOYAD, EGIUNVAN;
        private void FrmEgitimciAnaform_Load(object sender, EventArgs e)
        {
            
        UniBilgi();
            panel4.Visible = true;
            pictureBox2.Image = Properties.Resources.AboutGreen;
            label2.Text = EGIUNVAN + " " + EGIAD + " " + EGISOYAD;
            label3.Text = EGINO;
           
            //bilgigetir();
        } 
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
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

        
        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            FRMACILISFORMU frm = new FRMACILISFORMU();
            this.Close();
            frm.Show();
            
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;


            YonetimPaneli.FrmDersAc2 frm = new YonetimPaneli.FrmDersAc2();
            frm.EGINO = EGINO;
            frm.EGIAD = EGIAD;
            frm.EGISOYAD = EGISOYAD;
            frm.EGIUNVAN = EGIUNVAN;
            frm.ShowDialog();
        
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
            button2.BackColor = Color.FromArgb(5, 101, 220);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;


            YonetimPaneli.FrmNotGirisi frm = new YonetimPaneli.FrmNotGirisi();
            frm.EGINO = EGINO;
            frm.EGIAD = EGIAD;
            frm.EGISOYAD = EGISOYAD;
            frm.EGIUNVAN = EGIUNVAN;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;


            YonetimPaneli.FrmDevamsizlikKaydı frm = new YonetimPaneli.FrmDevamsizlikKaydı();
            frm.EGINO = EGINO;
            frm.EGIAD = EGIAD;
            frm.EGISOYAD = EGISOYAD;
            frm.EGIUNVAN = EGIUNVAN;
            frm.ShowDialog();
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.FromArgb(151, 0, 166);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutWhite;
            panel4.Visible = false;


            YonetimPaneli.FrmAKADEMISYENGUNCELLE frm = new YonetimPaneli.FrmAKADEMISYENGUNCELLE();
            frm.EGINO = EGINO;
            frm.EGIAD = EGIAD;
            frm.EGISOYAD = EGISOYAD;
            frm.EGIUNVAN = EGIUNVAN;
            frm.ShowDialog();
        }

        

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.FromArgb(247, 0, 0);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAkademiGiris frm = new FrmAkademiGiris();
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Çıkış yapmak istiyor musun ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secim == DialogResult.Yes)
            {
                frm.Show();
                this.Close();
            }
        }

        private void button8_MouseMove(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.Orange;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            
            
                                                
                pictureBox2.Image = Properties.Resources.AboutWhite;
                panel4.Visible = false;

                YonetimPaneli.FrmAkademisyenDuyurulariGoruntule frm = new YonetimPaneli.FrmAkademisyenDuyurulariGoruntule();
                frm.ShowDialog();
                
            

            
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.AboutGreen;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (panel4.Visible == false)
            {
                pictureBox2.Image = Properties.Resources.AboutWhite;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.AboutGreen;
            }
        }

        private void FrmEgitimciANAFORM_Activated(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_EgiDetay where EGINO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", EGINO);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                label4.Text = oku["EGIFAKULTE"].ToString();
                label5.Text = oku["EGIBOLUM"].ToString();
                pictureBox3.ImageLocation = oku["EGIRESIM"].ToString();
            }
            baglanti.Close();
        }

       

    }
}
