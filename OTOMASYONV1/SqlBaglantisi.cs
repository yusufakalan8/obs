using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OTOMASYONV1
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OgrenciİsleriOtomasyonu_VT;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }
    }
}
