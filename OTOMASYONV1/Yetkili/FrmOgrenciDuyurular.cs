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


namespace OTOMASYONV1.Yetkili
{
    public partial class FrmOgrenciDuyurular : Form
    {
        public FrmOgrenciDuyurular()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");


        void duyuru()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_OgrenciDuyurular",  baglanti);
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
            
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 167, 73);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            //baş kısım
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 70;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 60;
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
            


            dataGridView1.ColumnHeadersVisible = false;


            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional




        }

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            duyuru();
        }

        private void FrmDuyurular_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
