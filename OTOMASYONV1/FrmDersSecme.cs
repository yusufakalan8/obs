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
    public partial class FrmDersSecme : Form
    {
        public FrmDersSecme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");

        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                    
         
        
        void derslistesi()
        {
            dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

           
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 20;
            dataGridView1.Columns[4].Width = 210;
            dataGridView1.Columns[5].Width = 180;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 40;


            this.dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);


            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ReadOnly = true; dataGridView3.ReadOnly = true; 
            dataGridView1.RowHeadersVisible = false;
               dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
         //dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //Veriye tıklandığında satır seçimi sağlama.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        
            //datagridview2 Sütunları oluştur
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Name = "ID";
            dataGridView2.Columns[2].Name = "Kategori";
            dataGridView2.Columns[3].Name = "Açıklama";
            dataGridView2.Columns[4].Name = "ID";
            dataGridView2.Columns[5].Name = "Kategori";
            dataGridView2.Columns[6].Name = "Açıklama";
          
            dataGridView1.ColumnHeadersVisible = false;
            

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            

        }


        void secilenderslistesi()
        {
            dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 167, 73);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView2.BackgroundColor = Color.White;
            //baş kısım
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView2.ColumnHeadersHeight = 40;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 70;
            }

            dataGridView2.EnableHeadersVisualStyles = false;



            this.dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);


            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //Veriye tıklandığında satır seçimi sağlama.
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //datagridview2 Sütunları oluştur
            dataGridView2.ColumnCount = 7;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Name = "ID";
            dataGridView2.Columns[2].Name = "Kategori";
            dataGridView2.Columns[3].Name = "Açıklama";
            dataGridView2.Columns[4].Name = "ID";
            dataGridView2.Columns[5].Name = "Kategori";
            dataGridView2.Columns[6].Name = "Açıklama";
            dataGridView2.Columns[1].Width = 60;
            
            dataGridView2.Columns[2].Width = 90;
            
            dataGridView2.Columns[3].Width = 210;
            
            dataGridView2.Columns[4].Width = 180;
            
            dataGridView2.Columns[5].Width = 200;
            
            dataGridView2.Columns[6].Width = 40;
            

            dataGridView2.ColumnHeadersVisible = false;
            

            dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            

        }
        void secilenderslistesi3()
        {
            dataGridView3.AllowUserToAddRows = false;

            this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 167, 73);
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView3.BackgroundColor = Color.White;
            //baş kısım
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView3.ColumnHeadersHeight = 40;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 70;
            }

            dataGridView3.EnableHeadersVisualStyles = false;



            this.dataGridView3.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 12);


            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView3.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //Veriye tıklandığında satır seçimi sağlama.
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //datagridview2 Sütunları oluştur
            dataGridView3.ColumnCount = 7;
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Name = "ID";
            dataGridView3.Columns[2].Name = "Kategori";
            dataGridView3.Columns[3].Name = "Açıklama";
            dataGridView3.Columns[4].Name = "ID";
            dataGridView3.Columns[5].Name = "Kategori";
            dataGridView3.Columns[6].Name = "Açıklama";
            dataGridView3.Columns[1].Width = 60;
            
            dataGridView3.Columns[2].Width = 90;
            
            dataGridView3.Columns[3].Width = 210;
            
            dataGridView3.Columns[4].Width = 180;
            
            dataGridView3.Columns[5].Width = 200;
            
            dataGridView3.Columns[6].Width = 40;
            

            dataGridView3.ColumnHeadersVisible = false;
            

            dataGridView3.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            

        }

        public string DERSBOLUM,OGRNO;
        private void FrmDersSecme_Load(object sender, EventArgs e)
        {



            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_Secilen where SECEN=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", OGRNO);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Close();
                MessageBox.Show("Seçme işlemi Daha önceden yapılmış"); 
            }
           
            baglanti.Close();




            secilenderslistesi();
            secilenderslistesi3();
          
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

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }

                this.dataGridView2.Rows.Add(rowData);
                dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }

                this.dataGridView3.Rows.Add(rowData);
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
        }

        

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.PlusGreen;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.PlusWhite;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;

                }
                this.dataGridView2.Rows.Add(rowData);
                
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.PlusGreen;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.PlusWhite;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Image = Properties.Resources.DeleteGreen;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.DeleteWhite;

        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.Image = Properties.Resources.SaveRadionButtonAhover;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.SaveRadionButton;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            //Sütun değerlerini toplama
            int toplam = 0;
        
            for (int i = 0; i < dataGridView3.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value);
            }
            if (toplam==0)
            {
                MessageBox.Show("Listeye Ders Eklenmedi!");
            }
            else if (toplam>=15)
            {
                MessageBox.Show("15 Krediden fazla ders alınamaz");
            }
            else
            {
                for (int i = 0; i < dataGridView3.Rows.Count ; i++)
                {
                    SqlCommand cmd = new SqlCommand("insert into Tbl_Secilen (DERSNO, SECEN) values (@p2, @p1)", baglanti);
                    cmd.Parameters.AddWithValue("@p1", OGRNO);
                    cmd.Parameters.AddWithValue("@p2", dataGridView3.Rows[i].Cells[1].Value.ToString());
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    SqlCommand cmd3 = new SqlCommand("insert into Tbl_Devamsizlik (DERSNO, OGRNO) values (@p2, @p1)", baglanti);
                    cmd3.Parameters.AddWithValue("@p1", OGRNO);
                    cmd3.Parameters.AddWithValue("@p2", dataGridView3.Rows[i].Cells[1].Value.ToString());
                    baglanti.Open();
                    cmd3.ExecuteNonQuery();
                    baglanti.Close();
                }

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("update Tbl_Dersler set DERSKONT=(DERSKONT-1) WHERE DERSNO=@p1", baglanti);
                    cmd2.Parameters.AddWithValue("@p1", dataGridView3.Rows[i].Cells[1].Value.ToString());
                    baglanti.Open();
                    cmd2.ExecuteNonQuery();
                    baglanti.Close();
                } 

                
                  
                this.Close();
                MessageBox.Show("SEÇME BAŞARILI!");

            }
          
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
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

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
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
