using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiyLayer;
using DataAccessLayer;
using LogicLayer;

namespace NkatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonellistesi();
            dataGridView1.DataSource = PerList;

        }

        private void btnkekle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent=new EntityPersonel();
            ent.Ad = txtad.Text;
            ent.Soyad = txtsoyad.Text;
            ent.Sehir = txtsehir.Text;
            ent.Maas=short.Parse(txtmaas.Text);
            ent.Gorev=txtgorev.Text;

           LogicPersonel.LLPersonelEkle(ent);



        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent= new EntityPersonel();
            ent.Id=Convert.ToInt32(txtid.Text);
            LogicPersonel.LLPersonelSİl(ent.Id);

        }

        private void btguncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent=new EntityPersonel();
            ent.Id = Convert.ToInt32(txtid.Text);
            ent.Ad=txtad.Text;
            ent.Soyad=txtsoyad.Text;
            ent.Maas=short.Parse(txtmaas.Text);
            ent.Gorev = txtgorev.Text;
            ent.Sehir=txtsehir.Text;
            LogicPersonel.LLPersonelGuncelle(ent);



        }
    }
}
