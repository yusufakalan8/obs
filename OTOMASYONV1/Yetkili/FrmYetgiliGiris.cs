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
using System.Diagnostics.Eventing.Reader;

namespace OTOMASYONV1.Yetkili
{
    public partial class FrmYetgiliGiris : Form
    {
        public FrmYetgiliGiris()
        {
            InitializeComponent();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void FrmYetgiliGiris_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            guvenlikoduolusutur();
        }

        
        void guvenlikoduolusutur()
        {
            Random rastgele = new Random();
            string semboller = "1234567890asdfghjkşiçömnbvcxzüğpouuytrewqQWERTYUOPĞÜİŞLKJHGFADSÇÖMNBVCXZ";
            string olustur = "";
            for (int i = 0; i < 4; i++)
            {
                olustur += semboller[rastgele.Next(semboller.Length)];
            }
            label5.Text = olustur.ToString();
            
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "") {
                    if (textBox3.Text != "")
                    {

                        if (textBox1.TextLength < 10)
                        {
                            MessageBox.Show("Numaranız 10 Haneli Olmalıdır!!!");
                        }
                        else
                        {
                            if (textBox3.Text == label5.Text)
                            {
                                baglanti.Open();
                                SqlCommand komut = new SqlCommand("select * from Tbl_Yetkililer where YGNO=@p1 and YGSIFRE=@p2", baglanti);
                                komut.Parameters.AddWithValue("@p1", textBox1.Text.ToString());
                                komut.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
                                SqlDataReader oku = komut.ExecuteReader();
                                if (oku.Read())
                                {
                                    Yetkili.FrmYetkiliANAFORM frm = new Yetkili.FrmYetkiliANAFORM();
                                    frm.YGNO = oku["YGNO"].ToString();
                                    frm.YGADI = oku["YGADI"].ToString();
                                    frm.YGSOYAD = oku["YGSOYAD"].ToString();
                                    //frm.Pb_Resim.ImageLocation = oku["resim"].ToString();
                                    frm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("PROGRAM SORUMLUSU KAYDI BULUNAMADI");
                                }
                                baglanti.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen güvenlik kodunu doğru giriniz!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik kodu alanı boş geçilemez !!!");
                    }

                }
                else
                {
                    MessageBox.Show("Şifre alanı boş geçilemez");
                }
            }
            else
            {
                MessageBox.Show("Yetkili numarası alanı boş geçilemez");
            }
                    
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(82, 182, 98);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(17, 29, 44);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//TXTProgramSorumlusuNo textboxuna sadece sayı girilmesinibu kodla sağladık
        }

        private void LBL_GeriDon_Click(object sender, EventArgs e)
        {
            FRMACILISFORMU FRM = new FRMACILISFORMU();
            FRM.Show();
            this.Hide();
        }

        private void FrmYetgiliGiris_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void PbDegistir_Click(object sender, EventArgs e)
        {
            guvenlikoduolusutur();
            
        }

        private void FrmYetgiliGiris_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
