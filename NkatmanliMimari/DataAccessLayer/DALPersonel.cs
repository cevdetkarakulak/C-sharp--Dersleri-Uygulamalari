using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EntitiyLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel>degerler=new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * From TBLBILGI", Baglanti.bgl);
            if (komut1.Connection.State!=ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr=komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Maas = short.Parse( dr["AD"].ToString());
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }

    }
}
