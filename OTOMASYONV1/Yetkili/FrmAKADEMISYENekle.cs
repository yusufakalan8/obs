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
    public partial class FrmAKADEMISYENekle : Form
    {
        public FrmAKADEMISYENekle()
        {
            InitializeComponent();
        }

        private void FrmAKADEMISYENekle_Load(object sender, EventArgs e)
        {
            olustur();
            fakulteCek();
            getir();
        }

        void olustur()
        {
            Random rastgele = new Random();
           
            string semboller = "1234567890123456789012345678901234567890123456789012345678901234567890";
            string olustur = "";
            for (int i = 1; i < 11; i++)
            {
                olustur += semboller[rastgele.Next(semboller.Length)];
            }
            textBox4.Text = olustur.ToString();
            textBox3.Text = olustur.ToString();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        void fakulteCek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select FAKULTE from Tbl_Fakulteler ORDER BY FAKULTE ASC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["FAKULTE"]);
            }
            baglanti.Close();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void bolumlistesigetir()
        {
            comboBox3.Items.Clear();
            baglanti.Open(); SqlCommand komut = new SqlCommand("select * from Tbl_Bolumler where FAKULTEADI=@p1 ORDER BY BOLUMADI ASC ", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox2.SelectedItem);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["BOLUMADI"]);
            }
            baglanti.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bolumlistesigetir();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text.ToString() != null && comboBox2.Text.ToString() != null && comboBox3.Text.ToString() != null)
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select EGINO from Tbl_Egitimci where EGINO=@p1", baglanti);
                cmd.Parameters.AddWithValue("@p1", textBox3.Text.ToString());
                SqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    olustur();
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Tbl_Egitimci (EGIAD,EGISOYAD,EGIUNVAN,EGINO,EGISIFRE) Values (@p1,@p2,@p3,@p4,@p5)", baglanti);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text.ToUpper());
                    komut.Parameters.AddWithValue("@p2", textBox2.Text.ToUpper());
                    komut.Parameters.AddWithValue("@p3", comboBox1.Text.ToString());
                    komut.Parameters.AddWithValue("@p4", textBox3.Text.ToString().Trim());
                    komut.Parameters.AddWithValue("@p5", textBox4.Text.ToString().Trim());
                    komut.ExecuteNonQuery();

                    SqlCommand komut2 = new SqlCommand("insert into Tbl_EgiDetay (EGINO,EGIFAKULTE,EGIBOLUM,EGIRESIM) Values (@p0,@p1,@p2,@p3)", baglanti);
                    komut2.Parameters.AddWithValue("@p0", textBox3.Text.ToString().Trim());
                    komut2.Parameters.AddWithValue("@p1", comboBox2.Text.ToString());
                    komut2.Parameters.AddWithValue("@p2", comboBox3.Text.ToString());
                    komut2.Parameters.AddWithValue("@p3",textBox5.Text.ToString());
                    komut2.ExecuteNonQuery();

                    baglanti.Close();                   
                    MessageBox.Show("Akademisyen  Kaydı Başarıyla Eklendi");
                    this.Controls.Clear();
                    this.InitializeComponent();
                    olustur();
                    fakulteCek();
                    getir();
                    hocaarttir();

                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
            }
        }


        void hocaarttir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Uninfo set UNIESAY+=1", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        void hocaazalt()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Uninfo set UNIESAY-=1", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }


        



        void getir()
        {
            baglanti.Open();

            
            SqlCommand komut = new SqlCommand("select Tbl_Egitimci.ID, Tbl_Egitimci.EGINO,Tbl_Egitimci.EGISIFRE ,Tbl_Egitimci.EGIAD, Tbl_Egitimci.EGISOYAD, Tbl_Egitimci.EGIUNVAN, Tbl_EgiDetay.EGIFAKULTE, Tbl_EgiDetay.EGIBOLUM,Tbl_EgiDetay.EGIRESIM from Tbl_Egitimci inner join Tbl_EgiDetay on Tbl_Egitimci.EGINO=Tbl_EgiDetay.EGINO", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            tasarim();
        }

        void tasarim()
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
                row.Height = 30;
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
            ////dataGridView1.Columns[6].Visible = false;
            ////dataGridView1.Columns[1].Width = 40;
            ////dataGridView1.Columns[2].Width = 90;
            //////// dataGridView1.Columns[1].HeaderText = "KODU";
            ////dataGridView1.Columns[3].Width = 25;
            //////// dataGridView1.Columns[2].HeaderText = "TÜRÜ";
            ////dataGridView1.Columns[4].Width = 210;
            //////// dataGridView1.Columns[3].HeaderText = "ADI";
            ////dataGridView1.Columns[5].Width = 180;
            ////////   dataGridView1.Colmns[4].HeaderText = "BÖLÜMÜ";
            //////dataGridView1.Columns[5].Width = 200;
            ////////  dataGridView1.Columns[5].HeaderText = "HOCASI";
            ////////  dataGridView1.Columns[6].Width = 40;
            //////// dataGridView1.Columns[6].HeaderText = "KONTENJANI";

            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text.ToString() != null && comboBox2.Text.ToString() != null && comboBox3.Text.ToString() != null)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Tbl_Egitimci where ID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("delete from Tbl_EgiDetay where ID=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                komut2.ExecuteNonQuery();


                baglanti.Close();
                hocaazalt();
                getir();
                this.Controls.Clear();
                this.InitializeComponent();
                olustur();
                fakulteCek();
                getir();
                MessageBox.Show("Akademisyen Kaydı Başarıyla Silindi!");

            }
            else
            {
                MessageBox.Show("Lütfen Bir Seçim Yapınız!");
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text.ToString() != null && comboBox2.Text.ToString() != null && comboBox3.Text.ToString() != null)
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select EGINO from Tbl_Egitimci where EGINO=@p1", baglanti);
                cmd.Parameters.AddWithValue("@p1", textBox3.Text.ToString());
                SqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    olustur();
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update Tbl_Egitimci set EGIAD=@p1,EGISOYAD=@p2,EGIUNVAN=@p3 where EGINO=@p4", baglanti);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text.ToString().ToUpper());
                    komut.Parameters.AddWithValue("@p2", textBox2.Text.ToString().ToUpper());
                    komut.Parameters.AddWithValue("@p3", comboBox1.Text.ToString());
                    komut.Parameters.AddWithValue("@p4", egiNo.ToString());
                    


                    SqlCommand komut2 = new SqlCommand("update Tbl_EgiDetay set EGIFAKULTE=@p1,EGIBOLUM=@p2,EGIRESIM=@p3 where EGINO=@p4", baglanti);
                    komut2.Parameters.AddWithValue("@p4", egiNo.ToString());
                    komut2.Parameters.AddWithValue("@p1", comboBox2.Text.ToString());
                    komut2.Parameters.AddWithValue("@p2", comboBox3.Text.ToString());
                    komut2.Parameters.AddWithValue("@p3", textBox5.Text.ToString());

                    komut2.ExecuteNonQuery();
                    komut.ExecuteNonQuery();

                    baglanti.Close();
                    getir();
                    olustur();
                    MessageBox.Show("Akademisyen Kaydı Başarıyla Düzenlendi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            olustur();
            fakulteCek();
            getir();


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            olustur();
        }

        

        private void FrmAKADEMISYENekle_Paint(object sender, PaintEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.PlusAhover;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.PlusDark;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Pb_EgiResim.ImageLocation = openFileDialog1.FileName;
            textBox5.Text = openFileDialog1.FileName;
        }

        string egiNo, egiSifre;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idNo = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            egiNo = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            egiSifre = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString().Trim();
            Pb_EgiResim.ImageLocation = textBox5.Text;
        }

        int idNo;

        
    }
}