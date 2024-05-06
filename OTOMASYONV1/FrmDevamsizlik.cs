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
    public partial class FrmDevamsizlik : Form
    {
        public FrmDevamsizlik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        public string DERSBOLUM, OGRNO;
        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }


        void notgetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Tbl_Dersler.DERSNO, Tbl_Dersler.DERSTURU, Tbl_Dersler.DERSKREDI, Tbl_Dersler.DERSAD, Tbl_Dersler.DERSHOCA, Tbl_Devamsizlik.GUN , Tbl_Devamsizlik.DURUM  from Tbl_Dersler inner join Tbl_Devamsizlik on Tbl_Dersler.DERSNO=Tbl_Devamsizlik.DERSNO where OGRNO=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", OGRNO);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
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
            
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 30;            
            dataGridView1.Columns[3].Width = 240;           
            dataGridView1.Columns[4].Width = 240;            
            dataGridView1.Columns[5].Width = 40;
            dataGridView1.ColumnHeadersVisible = false;
            

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            

        }

        private void FrmDevamsizlik_Load(object sender, EventArgs e)
        {
          
            notgetir();
            derslistesi();  bos();
        }
        void bos()
        {
            int kayitsayisi;
            kayitsayisi = dataGridView1.RowCount;
            if (kayitsayisi == 0)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
                // MessageBox.Show(kayitsayisi.ToString());
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                string kontrol = e.Value.ToString().Trim();

                if (kontrol == "KALDI")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (kontrol == "GEÇTİ")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }
    }
}
