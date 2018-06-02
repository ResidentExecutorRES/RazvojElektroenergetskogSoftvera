using Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{   
    public class Konekcija : IDanasnjiDatum
    {
        private string upit = "SELECT * FROM UneseneVrednosti WHERE CONVERT(DATE, VremeMerenja) = CONVERT(DATE, GETDATE())";
        public  List<PodaciIzBaze> DanasnjiDatum()
        {          
            Polja.conn.Open();          
            SqlCommand cmd = new SqlCommand(upit, Polja.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<PodaciIzBaze> retVal = new List<PodaciIzBaze>();

            while (reader.Read())
                retVal.Add(new PodaciIzBaze((string)reader.GetSqlString(0), reader.GetSqlDateTime(1), (float)reader.GetSqlDouble(2)));

            reader.Close();
            Polja.conn.Close();

            return retVal;
        }
    }
}
