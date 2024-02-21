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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities();
        
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TblKategori.Count().ToString();
            label3.Text = db.TblUrun.Count().ToString();
            label5.Text = db.TblMusteri.Count(x=>x.DURUM==true).ToString();
            label7.Text = db.TblMusteri.Count(x=>x.DURUM==false).ToString();
            label13.Text = db.TblUrun.Sum(x => x.STOK).ToString();
            label13.Text = db.TblUrun.Sum(x => x.STOK).ToString();
            label21.Text = db.TblSatis.Sum(x => x.FIYAT).ToString()+ " TL ";
            label13.Text = db.TblUrun.Sum(x => x.STOK).ToString();
            label11.Text = (from x in db.TblUrun orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text = (from x in db.TblUrun orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            label15.Text = db.TblUrun.Count(x => x.KATEGORI==1).ToString();
            label17.Text = db.TblUrun.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            label23.Text = (from x in db.TblMusteri select x.SEHIR).Distinct().Count().ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();

        }
    }
}
