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
namespace OTOMASYONV1
{
    public partial class FrmOgrenciBilgiGuncelle : Form
    {
        public FrmOgrenciBilgiGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        public string OGRNO;
        public string eskiSifre;

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOgrenciBilgiGuncelle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select OGRSIFRE from Tbl_Ogrenciler where OGRNO=@P1", baglanti);
            komut.Parameters.AddWithValue("@p1", OGRNO);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                eskiSifre = oku["OGRSIFRE"].ToString();

            }

            baglanti.Close();
        }
      

        private void FrmOgrenciBilgiGuncelle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void CHK_GuvenlikOnayi_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_GuvenlikOnayi.Checked == true)
            {
                BTN_Guncelle.Enabled = true;
            }

            if (CHK_GuvenlikOnayi.Checked == false)
            {
                BTN_Guncelle.Enabled = false;
            }
        }

        private void CHK_SifreAcKapat3_CheckedChanged(object sender, EventArgs e)
        {
            if (TXT_Sifre_Degistirme_Alani2.UseSystemPasswordChar == true)
            {
                TXT_Sifre_Degistirme_Alani2.UseSystemPasswordChar = false;
            }
            else
            {
                TXT_Sifre_Degistirme_Alani2.UseSystemPasswordChar = true;
            }
        }

        private void CHK_SifreAcKapat2_CheckedChanged(object sender, EventArgs e)
        {
            if (TXT_Sifre_Degistirme_Alani1.UseSystemPasswordChar == true)
            {
                TXT_Sifre_Degistirme_Alani1.UseSystemPasswordChar = false;
            }
            else
            {
                TXT_Sifre_Degistirme_Alani1.UseSystemPasswordChar = true;
            }
        }

        private void CHK_SifreAcKapat1_CheckedChanged(object sender, EventArgs e)
        {
            if (Txt_EskiSifre.UseSystemPasswordChar == true)
            {
                Txt_EskiSifre.UseSystemPasswordChar = false;
            }
            else
            {
                Txt_EskiSifre.UseSystemPasswordChar = true;
            }
        }

        private void BTN_Guncelle_Click(object sender, EventArgs e)
        {
            BTN_Guncelle.Enabled = false;

            if (TXT_Sifre_Degistirme_Alani1.Text != "")
            {
                if (TXT_Sifre_Degistirme_Alani1.TextLength >= 6 && TXT_Sifre_Degistirme_Alani2.TextLength >= 6)

                    if (eskiSifre == Txt_EskiSifre.Text)
                    {
                        if (TXT_Sifre_Degistirme_Alani1.Text == TXT_Sifre_Degistirme_Alani2.Text)
                        {
                            if ((TXT_Sifre_Degistirme_Alani1.Text != eskiSifre) && (TXT_Sifre_Degistirme_Alani2.Text != eskiSifre))
                            {
                                BTN_Guncelle.Enabled = true;
                                baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Ogrenciler SET OGRSIFRE=@P1 WHERE OGRNO=@P2", baglanti);
                                komut2.Parameters.AddWithValue("@P1", TXT_Sifre_Degistirme_Alani1.Text);
                                komut2.Parameters.AddWithValue("@P2", OGRNO);
                                komut2.ExecuteNonQuery();
                                baglanti.Close();
                                MessageBox.Show("Şifre Güncellendi");
                                CHK_GuvenlikOnayi.Checked = false;
                                BTN_Guncelle.Enabled = false;

                            }
                            else
                            {
                                MessageBox.Show("Lütfen yeni bir şifre girin !!!");
                            }
                        }

                        else
                        {
                            MessageBox.Show("Yeni şifre ile yeni şifre tekrar aynı olmalıdır");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Eski şifreniz yanlış lütfen eski şifrenizi tekrar giriniz");
                    }
                else
                {
                    MessageBox.Show("şifreniz en az 6 karakterden oluşmalıdır");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir şifre giriniz");
            }

            Txt_EskiSifre.Text = "";
            TXT_Sifre_Degistirme_Alani1.Text = "";
            TXT_Sifre_Degistirme_Alani2.Text = "";
            Txt_EskiSifre.Focus();
            CHK_GuvenlikOnayi.Checked = false;
        }

        private void BTN_Guncelle_MouseMove(object sender, MouseEventArgs e)
        {
            BTN_Guncelle.BackColor = Color.Orange;
        }

        private void BTN_Guncelle_MouseLeave(object sender, EventArgs e)
        {
            BTN_Guncelle.BackColor = Color.FromArgb(17, 28, 43);
        }
    }
}
