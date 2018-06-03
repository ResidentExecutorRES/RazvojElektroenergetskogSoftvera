using Contract;
using Contract.Interfaces;
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
        public  List<PodaciIzBaze> DanasnjiDatum()
        {
            IGetSelectQuery selectQuery = new GetSelectQuery();
            SqlCommands.conn.Open();          
            SqlCommands.cmd = new SqlCommand(selectQuery.GetFromUneseneVrednostiDate(), SqlCommands.conn);
            SqlDataReader reader = SqlCommands.cmd.ExecuteReader();
            List<PodaciIzBaze> retVal = new List<PodaciIzBaze>();

            while (reader.Read())
                retVal.Add(new PodaciIzBaze((string)reader.GetSqlString(0), reader.GetSqlDateTime(1), (float)reader.GetSqlDouble(2)));

            reader.Close();
            SqlCommands.conn.Close();

            return retVal;
        }
    }
}
