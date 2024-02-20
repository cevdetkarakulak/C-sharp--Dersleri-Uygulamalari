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

namespace Ogrenci_Proje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=Floppa\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KULUPAD";
            cmbkulup.ValueMember = "KULUPID";
            cmbkulup.DataSource = dt;
            baglanti.Close();
        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
           
           
            ds.OgrenciEkle(txtogrcadi.Text,txtogrcsoyadi.Text,byte.Parse(cmbkulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtogrcid.Text));
            MessageBox.Show("Öğrenci Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtogrcid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtogrcadi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtogrcsoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if(radioButton1.Text== dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())
            {
                radioButton1.Checked=true;
            }
            else if (radioButton2.Text == dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())
            {
                radioButton2.Checked=true;
            }
            else
            {
                radioButton1.Checked=false;
                radioButton2.Checked = false;
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtogrcadi.Text, txtogrcsoyadi.Text,byte.Parse( cmbkulup.SelectedValue.ToString()), c, int.Parse(txtogrcid.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void btnarama_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds.OgrenciAra(txtarama.Text);

        }
    }
}
