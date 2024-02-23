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


namespace Not_Kayit_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FLOPPA\SQLEXPRESS01;Initial Catalog=DbNotKayit;Integrated Security=True");

        void kalan()
        {
            
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from TBLDERS where durum='True'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblgecen.Text = Convert.ToInt16(dr[0]).ToString();
            }
            dr.Close();
            baglanti.Close();
        }
        void gecen()
        { baglanti.Open();
            SqlCommand cmd1 = new SqlCommand("select count(*) from TBLDERS where durum='False'", baglanti);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                lblkalan.Text = Convert.ToInt16(dr1[0]).ToString();
            }
            dr1.Close();
            baglanti.Close();

        }
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
           gecen();
           kalan();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", msknumara.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txts1.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txts2.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txts3.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;

            s1=Convert.ToDouble(txts1.Text);
            s2 = Convert.ToDouble(txts2.Text);
            s3 = Convert.ToDouble(txts3.Text);

            ortalama = (s1+s2+s3)/3;
            lblort.Text=ortalama.ToString();

            if (ortalama>=50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";    
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@p1,OGRS2=@p2, OGRS3=@p3,ORTALAMA=@p4,DURUM=@p5 where OGRNUMARA=@p6 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txts1.Text);
            komut.Parameters.AddWithValue("@p2", txts2.Text);
            komut.Parameters.AddWithValue("@p3", txts3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblort.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", msknumara.Text);
            komut.ExecuteNonQuery();          
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");        
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
           
           
        }     

    }
}

