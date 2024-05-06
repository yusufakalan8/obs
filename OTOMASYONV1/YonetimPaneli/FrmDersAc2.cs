using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTOMASYONV1.YonetimPaneli
{
    public partial class FrmDersAc2 : Form
    {
        public FrmDersAc2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        public string EGINO, EGIAD, EGISOYAD, EGIUNVAN, FAKULTENAME;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedItem.ToString() != null && comboBox2.SelectedItem.ToString() != null && comboBox3.SelectedItem.ToString() != null && comboBox4.SelectedItem.ToString() != null)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_Dersler (DERSNO,DERSTURU,DERSKREDI,DERSAD,DERSBOLUM,DERSHOCA,DERSKONT) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox1.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p3", comboBox2.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p4", textBox2.Text.ToUpper());
                komut.Parameters.AddWithValue("@p5", comboBox3.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p6", textBox3.Text);
                komut.Parameters.AddWithValue("@p7", comboBox4.SelectedItem.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                dersgetir();
                MessageBox.Show("Ders Başarıyla Eklendi!");
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
            }
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedItem.ToString() != null && comboBox2.SelectedItem.ToString() != null && comboBox3.SelectedItem.ToString() != null && comboBox4.SelectedItem.ToString() != null)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Tbl_Dersler set DERSNO=@p1,DERSTURU=@p2,DERSKREDI=@p3,DERSAD=@p4,DERSBOLUM=@p5,DERSHOCA=@p6,DERSKONT=@p7 where ID=@p8", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox1.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p3", comboBox2.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p4", textBox2.Text.ToUpper());
                komut.Parameters.AddWithValue("@p5", comboBox3.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p6", textBox3.Text);
                komut.Parameters.AddWithValue("@p7", comboBox4.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p8", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                dersgetir();
                MessageBox.Show("Ders Kaydı Başarıyla Düzenlendi!");

            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedItem.ToString() != null && comboBox2.SelectedItem.ToString() != null && comboBox3.SelectedItem.ToString() != null && comboBox4.SelectedItem.ToString() != null)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Tbl_Dersler where ID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                dersgetir();
                MessageBox.Show("Ders Kaydı Başarıyla Silindi!");

            }
            else
            {
                MessageBox.Show("Lütfen Bir Seçim Yapınız!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            dersgetir();
        }

        private void FrmDersAc2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//TXTOgrenciNo textboxuna sadece sayı girilebilmesini bu kodla sağladık
        }

        private void FrmDersAc2_Load(object sender, EventArgs e)
        {
            textBox3.Text = EGIUNVAN + " " + EGIAD + " " + EGISOYAD;
            // label3.Text = EGINO;

            // FAKULTENAME = "EĞİTİM FAKÜLTESİ";


            textBox3.Text = EGIUNVAN + " " + EGIAD + " " + EGISOYAD;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Tbl_EgiDetay where EGINO=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", EGINO);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                FAKULTENAME = oku2["EGIFAKULTE"].ToString();
            }
            baglanti.Close();


            for (int i = 1; i < 21; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }

            for (int i = 1; i < 101; i++)
            {
                comboBox4.Items.Add(i.ToString());
            }
            bolumCek();
            dersgetir();
        }

        void dersgetir()
        {
            baglanti.Open();

            //SqlCommand komut = new SqlCommand("Select Tbl_Dersler.DERSNO, Tbl_Dersler.DERSTURU, Tbl_Dersler.DERSKREDI, Tbl_Dersler.DERSAD, Tbl_Dersler.DERSBOLUM, Tbl_Dersler.DERSHOCA from Tbl_Dersler inner join Tbl_Secilen on Tbl_Dersler.DERSNO=Tbl_Secilen.DERSNO where SECEN=@p1", baglanti);
            SqlCommand komut = new SqlCommand("select * from Tbl_Dersler where DERSHOCA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", EGIUNVAN + " " + EGIAD + " " + EGISOYAD);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            dersler();
        }

        void bolumCek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Bolumler where FAKULTEADI=@p1 ORDER BY BOLUMADI ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", FAKULTENAME);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["BOLUMADI"]);
            }
            baglanti.Close();
        }

        void dersler()
        {
            dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 167, 73);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            //baş kısım
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 40;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 70;
            }

            dataGridView1.EnableHeadersVisualStyles = false;



            this.dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);


            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //Veriye tıklandığında satır seçimi sağlama.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].Width = 90;
            //// dataGridView1.Columns[1].HeaderText = "KODU";
            dataGridView1.Columns[3].Width = 25;
            //// dataGridView1.Columns[2].HeaderText = "TÜRÜ";
            dataGridView1.Columns[4].Width = 210;
            //// dataGridView1.Columns[3].HeaderText = "ADI";
            dataGridView1.Columns[5].Width = 180;
            ////   dataGridView1.Colmns[4].HeaderText = "BÖLÜMÜ";
            //dataGridView1.Columns[5].Width = 200;
            ////  dataGridView1.Columns[5].HeaderText = "HOCASI";
            ////  dataGridView1.Columns[6].Width = 40;
            //// dataGridView1.Columns[6].HeaderText = "KONTENJANI";

            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
    }
}
