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
namespace OTOMASYONV1.YonetimPaneli
{
    public partial class FrmDevamsizlikKaydı : Form
    {
        public FrmDevamsizlikKaydı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        public string EGINO, EGIAD, EGISOYAD, EGIUNVAN, FAKULTENAME;
        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDevamsizlikKaydı_Load(object sender, EventArgs e)
        {


            dersadicek();
            ogrenciler();

            int sayii = comboBox1.Items.Count;
            if (sayii == 0)
            {
                this.Close();
                MessageBox.Show("ÖNCE DERS EKLEMENİZ GEREKMEKTEDİR");
            }
        }


        DataTable yenile()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Tbl_Dersler.DERSNO, Tbl_Dersler.DERSTURU, Tbl_Dersler.DERSKREDI, Tbl_Devamsizlik.OGRNO, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_Devamsizlik.GUN, Tbl_Devamsizlik.DURUM from Tbl_Dersler inner join Tbl_Devamsizlik on ((Tbl_Dersler.DERSNO=Tbl_Devamsizlik.DERSNO) ) inner join Tbl_Ogrenciler ON (Tbl_Ogrenciler.OGRNO=Tbl_Devamsizlik.OGRNO) WHERE Tbl_Devamsizlik.DERSNO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox2.SelectedItem.ToString());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            return dt;
        }

        

        

       

        void ogrenciler()
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
            dataGridView1.ReadOnly = false; // sadece okunabilir olması yani veri düzenleme kapalı
            //Veriye tıklandığında satır seçimi sağlama.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[1].Width = 40;
            //dataGridView1.Columns[2].Width = 90;
            ////// dataGridView1.Columns[1].HeaderText = "KODU";
            //dataGridView1.Columns[3].Width = 25;
            ////// dataGridView1.Columns[2].HeaderText = "TÜRÜ";
            //dataGridView1.Columns[4].Width = 210;
            ////// dataGridView1.Columns[3].HeaderText = "ADI";
            //dataGridView1.Columns[5].Width = 180;
            //////   dataGridView1.Colmns[4].HeaderText = "BÖLÜMÜ";
            ////dataGridView1.Columns[5].Width = 200;
            //////  dataGridView1.Columns[5].HeaderText = "HOCASI";
            //////  dataGridView1.Columns[6].Width = 40;
            ////// dataGridView1.Columns[6].HeaderText = "KONTENJANI";

            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        void dersadicek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Dersler where DERSHOCA=@p1 ORDER BY DERSAD ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", EGIUNVAN + " " + EGIAD + " " + EGISOYAD);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["DERSAD"]);
                comboBox2.Items.Add(oku["DERSNO"]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
            dataGridView1.DataSource = yenile();
            dataGridView1.Columns["DERSNO"].ReadOnly = true;
            dataGridView1.Columns["DERSTURU"].ReadOnly = true;
            dataGridView1.Columns["DERSKREDI"].ReadOnly = true;
            dataGridView1.Columns["OGRNO"].ReadOnly = true;
            dataGridView1.Columns["OGRAD"].ReadOnly = true;
            dataGridView1.Columns["OGRSOYAD"].ReadOnly = true;
            
            ogrenciler();

            int kayitsayisi = dataGridView1.RowCount;
            if (kayitsayisi == 0)
            {
                MessageBox.Show("bu dersi seçen öğrenci bulunamadı!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                dataGridView1.AllowUserToAddRows = true;
                ////
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlCommand komut = new SqlCommand("update Tbl_Devamsizlik set GUN=@p1, DURUM=@p2 where OGRNO=@p4 AND DERSNO=@p5", baglanti);
                    komut.Parameters.AddWithValue("@p1", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    komut.Parameters.AddWithValue("@p2", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    komut.Parameters.AddWithValue("@p4", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    komut.Parameters.AddWithValue("@p5", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();


                }
                dataGridView1.DataSource = yenile();
               ogrenciler();
                MessageBox.Show("DEVAMSIZLIK EKLEME VEYA GÜNCELLEME İŞLEMİ BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTİRİLDİ","BİLGİ");

            }
            else
            {

                MessageBox.Show("ders seçiniz");
            }
        }
    }
}
