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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr= new FrmKulup();
            fr.Show();
        }

        private void btnders_Click(object sender, EventArgs e)
        {
            FrmDers fr= new FrmDers();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr= new FrmOgrenci();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar fr= new FrmSinavNotlar();    
            fr.Show();
        }
    }
}
