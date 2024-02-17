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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();
        private void btngirisyap_Click(object sender, EventArgs e)
        {
                SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2 ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", mskTC.Text);
                komut.Parameters.AddWithValue("@p2", txtsifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    FrmDoktorDetay frs = new FrmDoktorDetay();
                    frs.TC=mskTC.Text;
                    frs.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı TC & Şifre");
                }
                bgl.baglanti().Close();
            }
        }
    }

