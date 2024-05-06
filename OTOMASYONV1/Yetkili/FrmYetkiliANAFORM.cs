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
    public partial class FrmYetkiliANAFORM : Form
    {
        public FrmYetkiliANAFORM()
        {
            InitializeComponent();
        }
        public string YGNO, YGADI, YGSOYAD,REKTORNAME;
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        private void FrmYetkiliANAFORM_Load(object sender, EventArgs e)
        {
            REKTORNAME = s1.Text.ToString();
            UniBilgi();
           
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
        

        private void Btn_CikisYap_Click_1(object sender, EventArgs e)
        {
            FRMACILISFORMU frm = new FRMACILISFORMU();
            this.Close();
            frm.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yetkili.FrmFakBolEkle frm = new Yetkili.FrmFakBolEkle();
            frm.YGNO = YGNO;
            frm.YGADI = YGADI;
            frm.YGSOYAD = YGSOYAD;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         


            Yetkili.FrmBolumEkle frm = new Yetkili.FrmBolumEkle();
            frm.YGNO = YGNO;
            frm.YGADI = YGADI;
            frm.YGSOYAD = YGSOYAD;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Yetkili.FrmUniBilgiFormu frm = new Yetkili.FrmUniBilgiFormu();
            frm.ShowDialog();
        }

        private void FrmYetkiliANAFORM_Activated(object sender, EventArgs e)
        {
            UniBilgi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Yetkili.FrmAKADEMISYENekle ekle = new FrmAKADEMISYENekle();

            ekle.ShowDialog();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(5, 101, 220);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.FromArgb(151, 0, 166);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.FromArgb(206, 184, 21);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(17, 29, 44);
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
            Yetkili.FrmOgrenciEkle ekle = new Yetkili.FrmOgrenciEkle();

            ekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Yetkili.FrmOgrenciLISTESI ekle = new Yetkili.FrmOgrenciLISTESI();

            ekle.ShowDialog();
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.FromArgb(21, 188, 57);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Yetkili.FrmOgrenciDuyuruEkle frm = new Yetkili.FrmOgrenciDuyuruEkle();
            frm.ShowDialog();
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.Orange;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void button8_MouseMove(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.Purple;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Yetkili.FrmAkademisyenDuyuruEkle frm = new Yetkili.FrmAkademisyenDuyuruEkle();
            frm.ShowDialog();
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(17, 29, 44);
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
