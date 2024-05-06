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
    public partial class FrmOgrenciLISTESI : Form
    {
        public FrmOgrenciLISTESI()
        {
            InitializeComponent();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOgrenciLISTESI_Load(object sender, EventArgs e)
        {
            getir();
            bolumlistesigetir();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        void bolumlistesigetir()
        {

            comboBox1.Items.Clear();
            baglanti.Open(); SqlCommand komut = new SqlCommand("select * from Tbl_Bolumler ORDER BY BOLUMADI ASC ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["BOLUMADI"]);
            }
            baglanti.Close();
        }
        void getir()
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Tbl_Ogrenciler.ID, Tbl_Ogrenciler.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_OgrenciDetay.OGRBOLUM, Tbl_OgrenciDetay.OGRSINIF from Tbl_Ogrenciler inner join Tbl_OgrenciDetay on Tbl_Ogrenciler.OGRNO=Tbl_OgrenciDetay.OGRNO", baglanti);
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
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 68, 175);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            //baş kısım
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 40;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 60;
            }

            dataGridView1.EnableHeadersVisualStyles = false;



            this.dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);


            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //Veriye tıklandığında satır seçimi sağlama.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Width = 30;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Opacity = 0;
            this.Close();
            FrmOgrenciEkle ekle = new FrmOgrenciEkle();
            ekle.textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            ekle.textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            ekle.comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            ekle.comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            

            ekle.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             string srg = textBox1.Text;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Tbl_Ogrenciler.ID, Tbl_Ogrenciler.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_OgrenciDetay.OGRBOLUM, Tbl_OgrenciDetay.OGRSINIF from Tbl_Ogrenciler inner join Tbl_OgrenciDetay on Tbl_Ogrenciler.OGRNO=Tbl_OgrenciDetay.OGRNO where Tbl_OgrenciDetay.OGRNO Like '%" + srg + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            tasarim();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string srg = textBox2.Text;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Tbl_Ogrenciler.ID, Tbl_Ogrenciler.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_OgrenciDetay.OGRBOLUM, Tbl_OgrenciDetay.OGRSINIF from Tbl_Ogrenciler inner join Tbl_OgrenciDetay on Tbl_Ogrenciler.OGRNO=Tbl_OgrenciDetay.OGRNO where Tbl_Ogrenciler.OGRAD Like '%" + srg + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            tasarim();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string srg = textBox3.Text;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Tbl_Ogrenciler.ID, Tbl_Ogrenciler.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_OgrenciDetay.OGRBOLUM, Tbl_OgrenciDetay.OGRSINIF from Tbl_Ogrenciler inner join Tbl_OgrenciDetay on Tbl_Ogrenciler.OGRNO=Tbl_OgrenciDetay.OGRNO where Tbl_Ogrenciler.OGRSOYAD Like '%" + srg + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            tasarim();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string srg = comboBox1.Text;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Tbl_Ogrenciler.ID, Tbl_Ogrenciler.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_OgrenciDetay.OGRBOLUM, Tbl_OgrenciDetay.OGRSINIF from Tbl_Ogrenciler inner join Tbl_OgrenciDetay on Tbl_Ogrenciler.OGRNO=Tbl_OgrenciDetay.OGRNO WHERE Tbl_OgrenciDetay.OGRBOLUM=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",srg);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            tasarim();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string srg = comboBox2.Text;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Tbl_Ogrenciler.ID, Tbl_Ogrenciler.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD, Tbl_OgrenciDetay.OGRBOLUM, Tbl_OgrenciDetay.OGRSINIF from Tbl_Ogrenciler inner join Tbl_OgrenciDetay on Tbl_Ogrenciler.OGRNO=Tbl_OgrenciDetay.OGRNO WHERE Tbl_OgrenciDetay.OGRSINIF=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", srg);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            tasarim();
        }

        
    }
}