using Contract;
using KorisnickiInterfejs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{
    public class Connect : IConnect
    {
        private string selectUpit = "SELECT * FROM UneseneVrednosti";
        public List<PodaciIzBaze> VratiRedove()
        {
            SqlCommands.conn.Open();
            List<PodaciIzBaze> podaci = new List<PodaciIzBaze>();    
            SqlCommand cmd = new SqlCommand(selectUpit, SqlCommands.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
                podaci.Add(new PodaciIzBaze((string)reader.GetSqlString(0), 
                                            reader.GetSqlDateTime(1), 
                                            (float)reader.GetSqlDouble(2)));

            reader.Close();
            SqlCommands.conn.Close();

            return podaci;
        }
    }
}
