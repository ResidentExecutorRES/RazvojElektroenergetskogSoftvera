using Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{
    public class InsertCaluculationFunction : IInsertCulculationFunction
    {       
        public void PosaljiInsert(List<string> insertInto)
        {
            foreach (var item in insertInto)
            {
                using (SqlCommands.cmd = new SqlCommand(item, SqlCommands.conn))
                {
                    SqlCommands.conn.Open();
                    SqlCommands.cmd.ExecuteNonQuery();
                    SqlCommands.conn.Close();
                }
            }
        }
        private async void TaskCallback(object callback)
        {
            IUpisiCallback2 messageCallback = callback as IUpisiCallback2;

            for (int i = 0; i < 10; i++)
            {
                messageCallback.OnCallback("message " + i.ToString());
                await Task.Delay(1000);
            }
        }
    }
}
