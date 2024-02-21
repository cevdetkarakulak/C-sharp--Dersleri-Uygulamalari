using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityProjeUygulama;


namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var kategoriler =db.TblKategori.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            TblKategori t=new TblKategori();
            t.AD=txtkategoriad.Text;
            db.TblKategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt16(txtkategoriid.Text);
            var ktgr = db.TblKategori.Find(x);
            db.TblKategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtkategoriid.Text);
            var ktgr = db.TblKategori.Find(x);
            ktgr.AD = txtkategoriad.Text;
            db.SaveChanges();
            MessageBox.Show("Güncellme Yapıldı");
        }
    }
}
