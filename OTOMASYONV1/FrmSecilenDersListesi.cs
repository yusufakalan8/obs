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
    public partial class FrmSecilenDersListesi : Form
    {
        public FrmSecilenDersListesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        public string DERSBOLUM, OGRNO;
        private void FrmSecilenDersListesi_Load(object sender, EventArgs e)
        {


            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_Secilen where SECEN=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", OGRNO);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
            }
            else
            {
                this.Close();
                MessageBox.Show("Lütfen ders seçiniz");
            }

            baglanti.Close();


            baglanti.Open();
           // SqlCommand komut = new SqlCommand("Select urunler.urunKod,urunler.urunAd,urunler.urunFiyat,markalar.markaAd from urunler inner join markalar on urunler.urunMarkaKod=markalar.markaKod", baglanti);
            SqlCommand komut = new SqlCommand("Select Tbl_Dersler.DERSNO, Tbl_Dersler.DERSTURU, Tbl_Dersler.DERSKREDI, Tbl_Dersler.DERSAD, Tbl_Dersler.DERSBOLUM, Tbl_Dersler.DERSHOCA from Tbl_Dersler inner join Tbl_Secilen on Tbl_Dersler.DERSNO=Tbl_Secilen.DERSNO where SECEN=@p1", baglanti);
           // SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Dersler INNER JOIN Tbl_Secilen ON Tbl_Dersler.DERSNO = Tbl_Secilen.DERSNO where SECEN=@p1", baglanti);
         
            komut.Parameters.AddWithValue("@p1", OGRNO);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            derslistesi();
        }
        void derslistesi()
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
           // dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 70;
            // dataGridView1.Columns[1].HeaderText = "KODU";
            dataGridView1.Columns[2].Width = 20;
            // dataGridView1.Columns[2].HeaderText = "TÜRÜ";
            dataGridView1.Columns[3].Width = 210;
            // dataGridView1.Columns[3].HeaderText = "ADI";
            dataGridView1.Columns[4].Width = 180;
            //   dataGridView1.Colmns[4].HeaderText = "BÖLÜMÜ";
            dataGridView1.Columns[5].Width = 200;
            //  dataGridView1.Columns[5].HeaderText = "HOCASI";
           //  dataGridView1.Columns[6].Width = 40;
            // dataGridView1.Columns[6].HeaderText = "KONTENJANI";

            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                string kontrol = e.Value.ToString();

                if (kontrol == "ZORUNLU")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (kontrol == "SEÇMELİ")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }
    }
}
