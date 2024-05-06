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
    public partial class FrmUniBilgiFormu : Form
    {
        public FrmUniBilgiFormu()
        {
            InitializeComponent();
        }

        

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");




        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Tbl_UniNfo set UNIREKTOR=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text.ToString().ToUpper());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Rektör bilgisi güncellendi");
                UniBilgi();
            }
            else
            {
                MessageBox.Show("Rektör ismi alanı boş geçilemez");
            }
        }
        void UniBilgi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Uninfo", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                textBox1.Text = oku["UNIREKTOR"].ToString();
                Yetkili.FrmYetkiliANAFORM f = new Yetkili.FrmYetkiliANAFORM();
                f.REKTORNAME = oku["UNIREKTOR"].ToString();
               
            }
            baglanti.Close();
        }
        private void FrmUniBilgiFormu_Load(object sender, EventArgs e)
        {
            UniBilgi();
        }

        

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DarkBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(17, 28, 43);
        }

        private void FrmUniBilgiFormu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void FrmUniBilgiFormu_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
