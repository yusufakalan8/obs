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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
          public string DERSBOLUM;
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Dersler where DERSBOLUM=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", DERSBOLUM);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        derslistesi();
        }
        void gridkontorl()
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
              
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "ZORUNLU")
                {
                         dataGridView1.Columns[2].DefaultCellStyle.ForeColor= Color.Red;

                   // renk.ForeColor = Color.YellowGreen;
                }
                else if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "SEÇMELİ")
                {
                    dataGridView1.Columns[2].DefaultCellStyle.ForeColor=  Color.Green;
                   // renk.ForeColor = Color.Orange;
                }
                else
                {
                    renk.BackColor = Color.Red;
                    renk.ForeColor = Color.White;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
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
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].Width = 70;
            // dataGridView1.Columns[1].HeaderText = "KODU";
            dataGridView1.Columns[3].Width = 20;
            // dataGridView1.Columns[2].HeaderText = "TÜRÜ";
            dataGridView1.Columns[4].Width = 210;
            // dataGridView1.Columns[3].HeaderText = "ADI";
            dataGridView1.Columns[5].Width = 180;
            //   dataGridView1.Colmns[4].HeaderText = "BÖLÜMÜ";
            dataGridView1.Columns[6].Width = 200;
            //  dataGridView1.Columns[5].HeaderText = "HOCASI";
            dataGridView1.Columns[7].Width = 40;
           // dataGridView1.Columns[6].HeaderText = "KONTENJANI";

            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
      
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2 && e.Value!=null)
            {
                string kontrol = e.Value.ToString();

                if (kontrol=="ZORUNLU")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if(kontrol=="SEÇMELİ")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Dersler where DERSBOLUM=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", DERSBOLUM);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            derslistesi();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.RefreshWhite;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.RefreshGreen;
        }

        

    }
}
