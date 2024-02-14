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

namespace Personel_Kayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent(); 
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Floppa\\SQLEXPRESS01;Initial Catalog=Personel;Integrated Security=True");

        void temizle()
        {
            textBox1.Text = "";
            txtad.Text = string.Empty;
            Txtsoyad.Text = string.Empty;
            txtmeslek.Text = string.Empty;
            cmbsehir.Text = string.Empty;
            mskmaas.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet.Tbl_Personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2",Txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4",mskmaas.Text);
            komut.Parameters.AddWithValue("@p5",txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);



            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi");


            baglanti.Close();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                label8.Text = "True";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";

            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1",textBox1.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set Perad=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", Txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", textBox1.Text);
            komutguncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi");
            baglanti.Close();
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr = new Frmİstatistik(); 
            fr.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            FrmGrafik frg=new FrmGrafik();
                frg.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRap frm = new FrmRap();
            frm.Show();
        }
    }
}
                                                                                            