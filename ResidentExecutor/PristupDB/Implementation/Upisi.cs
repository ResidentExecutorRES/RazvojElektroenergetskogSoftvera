using Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{
    public class Upisi : IUpisi
    {
        public void PosaljiInsert(string insertInto)
        {
            using (SqlCommands.cmd = new SqlCommand(insertInto, SqlCommands.conn))
            {
                SqlCommands.conn.Open();
                SqlCommands.cmd.ExecuteNonQuery();
                SqlCommands.conn.Close();
            }
        }
        private async void TaskCallback(object callback)
        {
            IUpisiCallback messageCallback = callback as IUpisiCallback;

            for (int i = 0; i < 10; i++)
            {
                messageCallback.OnCallback("message " + i.ToString());
                await Task.Delay(1000);
            }
        }
    }
}
