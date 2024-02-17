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


namespace Proje_Hastane
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl= new SqlBaglanti();
        public string TC;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;

            //Doktor Ad Soyad

            SqlCommand komut= new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1",bgl.baglanti()); 
            komut.Parameters.AddWithValue("@p1",lblTC.Text);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read())
            {
                Lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor='"+Lbladsoyad.Text + "'",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr=new FrmDoktorBilgiDuzenle();
            fr.TCNo=lblTC.Text;
            fr.Show();

        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm=new FrmDuyurular();
            frm.Show();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            rchsikayet.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
