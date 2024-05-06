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
using System.Diagnostics.Eventing.Reader;

namespace OTOMASYONV1.YonetimPaneli
{
    public partial class FrmNotGirisi : Form
    {
        public FrmNotGirisi()
        {
            InitializeComponent();
        }
        


        

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
        public string EGINO, EGIAD, EGISOYAD, EGIUNVAN, FAKULTENAME;
        private void FrmNotGirisi_Load(object sender, EventArgs e)
        {
            
           dersadicek();
           dersler();


           int sayii = comboBox1.Items.Count;
           if (sayii==0)
           {
               this.Close();
               MessageBox.Show("ÖNCE DERS EKLEMENİZ GEREKMEKTEDİR","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
           }
          



           
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


        private void Btn_CikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
            dataGridView1.DataSource = yenile();
            dersler();
            dataGridView1.Columns["DURUM"].ReadOnly = true;
            dataGridView1.Columns["DERSNO"].ReadOnly = true;
            dataGridView1.Columns["SECEN"].ReadOnly = true;
            dataGridView1.Columns["ORTALAMA"].ReadOnly = true;
            dataGridView1.Columns["OGRAD"].ReadOnly = true;
            dataGridView1.Columns["OGRSOYAD"].ReadOnly = true;
            dataGridView1.Columns["DERSKREDI"].ReadOnly = true;
            dataGridView1.Columns["DERSTURU"].ReadOnly = true;
            int kayitsayisi = dataGridView1.RowCount;
            if (kayitsayisi == 0)
            {
                MessageBox.Show("BU DERSİ SEÇEN ÖĞRENCİ BULUNAMADI !!!");
            }

        }

       

        DataTable yenile()
        {
             
            

             SqlCommand komut = new SqlCommand("Select Tbl_Dersler.DERSNO, Tbl_Dersler.DERSTURU, Tbl_Dersler.DERSKREDI, Tbl_Secilen.SECEN, Tbl_Ogrenciler.OGRAD, Tbl_Ogrenciler.OGRSOYAD,  Tbl_Secilen.VIZE, Tbl_Secilen.FINAL,Tbl_Secilen.BUT, Tbl_Secilen.ORTALAMA, Tbl_Secilen.DURUM  from Tbl_Dersler inner join Tbl_Secilen on ((Tbl_Dersler.DERSNO=Tbl_Secilen.DERSNO) ) inner join Tbl_Ogrenciler ON (Tbl_Ogrenciler.OGRNO=Tbl_Secilen.SECEN) WHERE Tbl_Secilen.DERSNO=@p1", baglanti);


      
              komut.Parameters.AddWithValue("@p1", comboBox2.SelectedItem.ToString());
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                return dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= yenile();
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
            dataGridView1.ReadOnly = false;
            

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
        private void button2_Click(object sender, EventArgs e)
        {

            

            if (comboBox1.Text!="")
            {
                dataGridView1.AllowUserToAddRows = true;
                ////
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlCommand komut = new SqlCommand("update Tbl_Secilen set VIZE=@p1, FINAL=@p2,BUT=@p10,ORTALAMA=@p6,DURUM=@p7 where SECEN=@p4 AND DERSNO=@p5", baglanti);
                    komut.Parameters.AddWithValue("@p1", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    komut.Parameters.AddWithValue("@p2", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    komut.Parameters.AddWithValue("@p4", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    komut.Parameters.AddWithValue("@p10", dataGridView1.Rows[i].Cells[8].Value.ToString());
                    komut.Parameters.AddWithValue("@p5", dataGridView1.Rows[i].Cells[0].Value.ToString());
                








                if (dataGridView1.CurrentRow.Cells["VIZE"].Value.ToString() == "" || dataGridView1.CurrentRow.Cells["FINAL"].Value.ToString() =="")
                    {
                        MessageBox.Show("LÜTFEN VİZE VE FİNAL NOTLARINI GİRİN!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if((dataGridView1.CurrentRow.Cells["BUT"].Value.ToString()!="" )  || dataGridView1.CurrentRow.Cells["FINAL"].Value.ToString() == "")
                    {
                        // Toplamı almak istediğiniz sütunların adı veya indeksi
                        string column1Name = "VIZE";
                        string column2Name = "BUT";

                        // Hedef sütunun adı veya indeksi
                        string totalColumnName = "ORTALAMA";


                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            DataGridViewCell cell1 = row.Cells[column1Name];
                            DataGridViewCell cell2 = row.Cells[column2Name];

                            if (cell1.Value != null && cell2.Value != null)
                            {
                                int value1 = Convert.ToInt32(cell1.Value);
                                int value2 = Convert.ToInt32(cell2.Value);

                                // Değerleri 0 ile 100 arasında sınırla
                                if (value1 < 0 || value1 > 100)
                                {
                                    MessageBox.Show("Hata: Vize Notu 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cell1.Value = 0;
                                    komut.Parameters.AddWithValue("@p1", dataGridView1.Rows[i].Cells[6].Value.ToString());
                                    continue;
                                }

                                else if( value2 < 0 || value2 > 100)
                                {

                                    MessageBox.Show("Hata: Bütünleme Notu 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cell2.Value = 0;
                                    komut.Parameters.AddWithValue("@p10", dataGridView1.Rows[i].Cells[8].Value.ToString());
                                    continue;
                                }

                                else
                                {
                                    int total = Convert.ToInt32((value1 * 0.4) + (value2 * 0.6));

                                    DataGridViewCell totalCell = row.Cells[totalColumnName];
                                    totalCell.Value = total;
                                    // İlgili sütunların adı veya indeksi
                                    string notlarColumnName = "ORTALAMA";
                                    string durumColumnName = "DURUM";

                                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                                    {
                                        // "Notlar" sütunundaki hücreye erişim
                                        DataGridViewCell notlarCell = row1.Cells[notlarColumnName];
                                        //Final Notuna erişim
                                        DataGridViewCell butcell = row1.Cells[column2Name];
                                        int butnot = Convert.ToInt32(butcell.Value);
                                        // "Durum" sütununa erişim
                                        DataGridViewCell durumCell = row1.Cells[durumColumnName];

                                        // "Notlar" sütunundaki hücrenin değerini kontrol etme
                                        if (notlarCell.Value != null && int.TryParse(notlarCell.Value.ToString(), out int not))
                                        {
                                            // Değer 60 veya daha büyük mü diye kontrol etme
                                            if (not >= 60 && butnot >= 60)
                                            {
                                                durumCell.Value = "GEÇTİ";
                                            }
                                            else
                                            {
                                                durumCell.Value = "KALDI";

                                            }
                                        }
                                    }

                                    komut.Parameters.AddWithValue("@p6", dataGridView1.Rows[i].Cells[9].Value.ToString());
                                    komut.Parameters.AddWithValue("@p7", dataGridView1.Rows[i].Cells[10].Value.ToString());
                                    baglanti.Open();
                                    komut.ExecuteNonQuery();
                                    baglanti.Close();
                                    dataGridView1.DataSource = yenile();
                                    dersler();
                                }
                            }
                        }

                        


                        
                        
                       
                        
                    }

                    else
                    {

                        // Toplamı almak istediğiniz sütunların adı veya indeksi
                        string column1Name = "VIZE";
                        string column2Name = "FINAL";
                        

                        // Hedef sütunun adı veya indeksi
                        string totalColumnName = "ORTALAMA";
                        


                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            DataGridViewCell cell1 = row.Cells[column1Name];
                            DataGridViewCell cell2 = row.Cells[column2Name];

                            if (cell1.Value != null && cell2.Value != null)
                            {
                                int value1 = Convert.ToInt32(cell1.Value);
                                int value2 = Convert.ToInt32(cell2.Value);

                                // Değerleri 0 ile 100 arasında sınırla
                                if (value1 < 0 || value1 > 100)
                                {
                                    MessageBox.Show("Hata: Vize Notu 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cell1.Value = 0;
                                    komut.Parameters.AddWithValue("@p1", dataGridView1.Rows[i].Cells[6].Value.ToString());
                                    continue; 
                                   


                                }

                                else if (value2 < 0 || value2 > 100)
                                {


                                    MessageBox.Show("Hata: Final Notu 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cell2.Value = 0;
                                    komut.Parameters.AddWithValue("@p2", dataGridView1.Rows[i].Cells[7].Value.ToString());
                                    continue;
                                }
                                else
                                {
                                    int total = Convert.ToInt32((value1 * 0.4) + (value2 * 0.6));

                                    DataGridViewCell totalCell = row.Cells[totalColumnName];
                                    
                                    totalCell.Value = total;

                                    // İlgili sütunların adı veya indeksi
                                    string notlarColumnName = "ORTALAMA";
                                    string durumColumnName = "DURUM";

                                    foreach (DataGridViewRow row2 in dataGridView1.Rows)
                                    {
                                        // "Notlar" sütunundaki hücreye erişim
                                        DataGridViewCell notlarCell = row2.Cells[notlarColumnName];

                                        //Final Notuna erişim
                                        DataGridViewCell finalcell = row2.Cells[column2Name];
                                        int finalnot = Convert.ToInt32(finalcell.Value);
                                        // "Durum" sütununa erişim
                                        DataGridViewCell durumCell = row2.Cells[durumColumnName];

                                        // "Notlar" sütunundaki hücrenin değerini kontrol etme
                                        if (notlarCell.Value != null && int.TryParse(notlarCell.Value.ToString(), out int not))
                                        {
                                            // Değer 60 veya daha büyük mü diye kontrol etme
                                            if (not >= 60 && finalnot >= 60)
                                            {
                                                durumCell.Value = "GEÇTİ";

                                            }
                                            else
                                            {
                                                durumCell.Value = "KALDI";



                                            }
                                        }
                                    }

                                    komut.Parameters.AddWithValue("@p6", dataGridView1.Rows[i].Cells[9].Value.ToString());
                                    komut.Parameters.AddWithValue("@p7", dataGridView1.Rows[i].Cells[10].Value.ToString());
                                    baglanti.Open();
                                    komut.ExecuteNonQuery();
                                    
                                    dataGridView1.DataSource = yenile();
                                    baglanti.Close();
                                    dersler();
                                }

                            }
                        }

                        


                        
                        
                        
                    }
                }

            }
            else
            {

                MessageBox.Show("DERS SEÇİNİZ");
            }

        }

        
      
    }
}
