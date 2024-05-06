﻿using System;
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
    public partial class FrmBolumEkle : Form
    {
        public FrmBolumEkle()
        {
            InitializeComponent();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        public string YGNO, YGADI, YGSOYAD;
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        private void FrmBolumEkle_Load(object sender, EventArgs e)
        {
                fakultecek();
                bolumlistesigetir();

                int sayii = comboBox1.Items.Count;
                if (sayii == 0)
                {
                    this.Close();
                    MessageBox.Show("önce fakülte eklemeniz gerekmektedir.");
                }
          
        }
        void bolumarttir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Uninfo set UNIBOLSAY+=1", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        void bolumazalt()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Uninfo set UNIBOLSAY-=1", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        void fakultecek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select FAKULTE from Tbl_Fakulteler ORDER BY FAKULTE ASC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["FAKULTE"]);
              
            }
            baglanti.Close();
        }
        void bolumlistesigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Bolumler ORDER BY BOLUMADI ASC ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            gridtasarim();
        }

        void gridtasarim()
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
            dataGridView1.Columns[0].Visible = false; dataGridView1.Columns[2].Visible = false;
            

            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_Bolumler(BOLUMADI,FAKULTEADI) values (@p1,@p2)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text.ToUpper().ToString());
                komut.Parameters.AddWithValue("@p2", comboBox1.SelectedItem.ToString().ToUpper().Trim());
                komut.ExecuteNonQuery();
                baglanti.Close();
                bolumarttir();
                MessageBox.Show("Bölüm ekleme işlemi başarılı bir şekilde gerçekleştirildi");
                bolumlistesigetir();
                textBox1.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen bir bölüm adı giriniz!!!");
            }
        }
        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Tbl_Bolumler where ID=@p2", baglanti);
                komut.Parameters.AddWithValue("@p2", id);
                komut.ExecuteNonQuery();
                baglanti.Close();
                bolumazalt();
                MessageBox.Show("Bölüm silme işlemi başarılı bir şekilde gerçekleştirildi");
                bolumlistesigetir();
                textBox1.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen bir bölüm adı giriniz!!!");
            }
        }

        

        private void FrmBolumEkle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmBolumEkle_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Tbl_Bolumler set BOLUMADI=@p3,FAKULTEADI=@p1 where ID=@p2", baglanti);
                komut.Parameters.AddWithValue("@p3", textBox1.Text.ToString().ToUpper());
                komut.Parameters.AddWithValue("@p1", comboBox1.Text.ToString().Trim());
                komut.Parameters.AddWithValue("@p2", id);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Bölüm güncelleme işlemi başarılı bir şekilde gerçekleştirildi");
                bolumlistesigetir();
                textBox1.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen bir bölüm adı giriniz!!!");
            }
        }

        
    }
}
