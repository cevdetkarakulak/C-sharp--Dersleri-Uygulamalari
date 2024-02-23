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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

       SqlConnection baglanti=new SqlConnection(@"Data Source=FLOPPA\SQLEXPRESS01;Initial Catalog=DbNotKayit;Integrated Security=True");
            
        public string numara;
        string drm;
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblnumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2].ToString()+ " "+ dr[3].ToString(); 
                lbls1.Text = dr[4].ToString();
                lbls2.Text = dr[5].ToString();
                lbls3.Text = dr[6].ToString();
                lblort.Text = dr[7].ToString();
                drm = dr[8].ToString();
                if (drm=="True")
                {
                    lbldurum.Text = "Geçti";
                }
                else
                {
                    lbldurum.Text = "Kaldı";
                }
            }
            baglanti.Close();

        }
    }
}
