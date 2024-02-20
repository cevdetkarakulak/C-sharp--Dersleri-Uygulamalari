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
using System.Data.SqlClient;
namespace Ogrenci_Proje
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=Floppa\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True");
       
        private void btnarama_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtogrcid.Text));
        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DERSAD";
            cmbders.ValueMember = "DERSID";
            cmbders.DataSource = dt;
            baglanti.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtogrcid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int sinav1, sinav2, sinav3, proje;

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        double ortalama;
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
            //string durum;
            sinav1 = Convert.ToInt16(txtsinav1.Text);
            sinav2 = Convert.ToInt16(txtsinav2.Text);
            sinav3 = Convert.ToInt16(txtsinav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtortalama.Text=ortalama.ToString();
            if (ortalama>=50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbders.SelectedValue.ToString()), int.Parse(txtogrcid.Text), byte.Parse(txtsinav1.Text), byte.Parse(txtsinav2.Text),byte.Parse(txtsinav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text), notid);

        }
    }
}
