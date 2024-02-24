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

namespace Proje_Secim
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FLOPPA\SQLEXPRESS01;Initial Catalog=DbSecimProje;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtilcead.Text);
            komut.Parameters.AddWithValue("@P2", txtf.Text);
            komut.Parameters.AddWithValue("@P3", txtb.Text);
            komut.Parameters.AddWithValue("@P4", txtc.Text);
            komut.Parameters.AddWithValue("@P5", txtd.Text);
            komut.Parameters.AddWithValue("@P6", txte.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");


        }
        private void button2_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr=new FrmGrafikler();
            fr.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
