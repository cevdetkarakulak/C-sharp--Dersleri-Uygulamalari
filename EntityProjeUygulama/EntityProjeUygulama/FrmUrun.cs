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

namespace EntityProjeUygulama
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TblUrun
                                        select new
                                        {   x.URUNID, 
                                            x.URUNAD, 
                                            x.MARKA, 
                                            x.STOK, 
                                            x.FIYAT,
                                            x.TblKategori.AD, 
                                            x.DURUM 
                                        }).ToList() ;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblUrun t = new TblUrun();
            t.URUNAD = txtad.Text;
            t.MARKA = txtmarka.Text;
            t.STOK = short.Parse(txtstok.Text);
            t.KATEGORI = int.Parse(cmbkategori.SelectedValue.ToString());
            t.FIYAT = decimal.Parse(txtfiyat.Text);
            t.DURUM = true;
            db.TblUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtid.Text);
            var urun = db.TblUrun.Find(x);
            db.TblUrun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtid.Text);
            var urun = db.TblUrun.Find(x);
            urun.URUNAD = txtad.Text;
            urun.STOK = short.Parse(txtstok.Text);
            urun.MARKA = txtmarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TblKategori select new { x.ID, x.AD }).ToList();
            cmbkategori.ValueMember = "ID";
            cmbkategori.DisplayMember = "AD";
            cmbkategori.DataSource = kategoriler;


        }

        private void btntemizle_Click(object sender, EventArgs e)
        {

        }
    }
}
