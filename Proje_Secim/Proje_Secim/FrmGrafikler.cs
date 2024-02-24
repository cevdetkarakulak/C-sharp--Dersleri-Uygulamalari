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
using System.Windows.Forms.DataVisualization.Charting;

namespace Proje_Secim
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FLOPPA\SQLEXPRESS01;Initial Catalog=DbSecimProje;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //İlçe Adını ComboBox'a Getirme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCEAD from TBLILCE ", baglanti);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //Grafiğe Toplam Sonuçları Getirme

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE",baglanti);
            SqlDataReader DR2= komut2.ExecuteReader();  
            while(DR2.Read())
            {
                chart1.Series["PARTİLER"].Points.AddXY(" A PARTİ ",DR2[0]);
                chart1.Series["PARTİLER"].Points.AddXY(" B PARTİ ",DR2[1]);
                chart1.Series["PARTİLER"].Points.AddXY(" C PARTİ ",DR2[2]);
                chart1.Series["PARTİLER"].Points.AddXY(" D PARTİ ",DR2[3]);
                chart1.Series["PARTİLER"].Points.AddXY(" E PARTİ ",DR2[4]);                
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLILCE where ILCEAD=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lbla.Text = dr[2].ToString();
                lblb.Text = dr[3].ToString();
                lblc.Text = dr[4].ToString();
                lbld.Text = dr[5].ToString();
                lble.Text = dr[6].ToString();

            }
            baglanti.Close();
        }
    }
}
