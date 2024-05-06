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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
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

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            guvenlikoduolusutur();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                if(textBox2.Text != "")
                {
                    if(textBox3.Text != "") { 
                
                if (textBox1.TextLength < 10)
                {
                    MessageBox.Show("Örenci Numaranız 10 Haneli Olmalıdır!");
                }
                else
                {
                    if (textBox3.Text == label5.Text)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("select * from Tbl_Ogrenciler where OGRNO=@p1 and OGRSIFRE=@p2", baglanti);
                        komut.Parameters.AddWithValue("@p1", textBox1.Text.ToString());
                        komut.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
                        SqlDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            FrmAnaForm frm = new FrmAnaForm();
                            frm.OGRNO = oku["OGRNO"].ToString();
                            frm.OGRADI = oku["OGRAD"].ToString();
                            frm.OGRSOYADI = oku["OGRSOYAD"].ToString();
                            //frm.Pb_Resim.ImageLocation = oku["resim"].ToString();
                            frm.Show();
                            this.Hide();
                        }
                                else
                                {
                                    MessageBox.Show("ÖĞRENCİ KAYDI BULUNAMADI");
                                }



                                baglanti.Close();

                            }
                            else
                            {
                                MessageBox.Show("Güvenlik kodunu doğru giriniz!");
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
                    MessageBox.Show("Şifre alanı boş geçilemez !!!");
                }
            }
            else
            {
                MessageBox.Show("Öğrenci numarası alanı boş geçilemez !!!");
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//TXTOgrenciNo textboxuna sadece sayı girilebilmesini bu kodla sağladık
        }

        private void LBL_GeriDon_Click(object sender, EventArgs e)
        {
            FRMACILISFORMU FRM = new FRMACILISFORMU();
            FRM.Show();
            this.Hide();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void PbDegistir_Click(object sender, EventArgs e)
        {
            guvenlikoduolusutur();
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        
    }
}
  