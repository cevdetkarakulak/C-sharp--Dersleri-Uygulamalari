using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Proje
{
    public partial class FrmDers : Form
    {
        public FrmDers()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void FrmDers_Load(object sender, EventArgs e)
        {           
            dataGridView1.DataSource = ds.DersListesi();               
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtdersadi.Text);
            MessageBox.Show("Ders Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelleme(txtdersadi.Text, byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersadi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
