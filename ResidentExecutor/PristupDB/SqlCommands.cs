using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{
    public class SqlCommands
    {
        public static readonly SqlConnection conn = new SqlConnection(@"Server=DESKTOP-JJ3CM3A;  Database=ResidentExecutor_DB;  Integrated Security=True");
        public static SqlCommand cmd = null;
    }
}
