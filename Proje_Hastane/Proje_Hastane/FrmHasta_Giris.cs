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

    public partial class FrmHasta_Giris : Form
    {
        public FrmHasta_Giris()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();
        private void FrmHasta_Giris_Load(object sender, EventArgs e)
        {

        }

        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr=new FrmHastaKayit();
            fr.Show();
        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("p1", mskTC.Text);
            komut.Parameters.AddWithValue("p2", txtsifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                
                FrmHastaDetay fr = new FrmHastaDetay ();
                fr.tc=mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre");
            }
            bgl.baglanti().Close ();
        }
    }
}
