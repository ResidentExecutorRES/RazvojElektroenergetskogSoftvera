using Contract;
using Contract.Interfaces;
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
        public List<PodaciIzBaze> VratiRedove()
        {
            IGetSelectQuery selectQuery = new GetSelectQuery();
            SqlCommands.conn.Open();
            List<PodaciIzBaze> podaci = new List<PodaciIzBaze>();
            SqlCommands.cmd = new SqlCommand(selectQuery.GetFromUneseneVrednosti(), SqlCommands.conn);
            SqlDataReader reader = SqlCommands.cmd.ExecuteReader();

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
