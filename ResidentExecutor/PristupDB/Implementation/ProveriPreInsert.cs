using Contract;
using Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{
    public class ProveriPreInsert : IProveriPreInsert
    {
        private IGetSelectQuery getQuery = new GetSelectQuery();

        public Dictionary<string, List<CalculationTable>> PosaljiInsert()
        {
            List<CalculationTable> retVal2 = new List<CalculationTable>();
            Dictionary<string, List<CalculationTable>> retVal = new Dictionary<string, List<CalculationTable>>();

            #region IscitavanjeIzTabeleFunkcijaAverage
            SqlCommands.conn.Open();
            SqlCommands.cmd = new SqlCommand(getQuery.GetFromFunkcijaAverage(), SqlCommands.conn);
            SqlDataReader reader = SqlCommands.cmd.ExecuteReader();

            while (reader.Read())
                retVal2.Add(new CalculationTable((string)reader.GetSqlString(0),
                                                reader.GetSqlDateTime(1),
                                                (double)reader.GetSqlDouble(2),
                                                reader.GetSqlDateTime(4)));
            retVal.Add("AVG", retVal2);
            retVal2 = new List<CalculationTable>();
            reader.Close();

            #endregion

            #region  IscitavanjeIzTabeleFunkcijaMaximum
            SqlCommands.cmd = new SqlCommand(getQuery.GetFromFunkcijaMaximum(), SqlCommands.conn);
            reader = SqlCommands.cmd.ExecuteReader();

            while (reader.Read())
                retVal2.Add(new CalculationTable((string)reader.GetSqlString(0),
                                                reader.GetSqlDateTime(1),
                                                (double)reader.GetSqlDouble(2),
                                                reader.GetSqlDateTime(4)));
            retVal.Add("MAX", retVal2);
            retVal2 = new List<CalculationTable>();
            reader.Close();
            #endregion

            #region  IscitavanjeIzTabeleFunkcijaMinimum
            SqlCommands.cmd = new SqlCommand(getQuery.GetFromFunkcijaMinimum(), SqlCommands.conn);
            reader = SqlCommands.cmd.ExecuteReader();
            while (reader.Read())
                retVal2.Add(new CalculationTable((string)reader.GetSqlString(0),
                                                reader.GetSqlDateTime(1),
                                                (double)reader.GetSqlDouble(2),
                                                reader.GetSqlDateTime(4)));
            retVal.Add("MIN", retVal2);
            retVal2 = new List<CalculationTable>();
            reader.Close();
            SqlCommands.conn.Close();
            #endregion

            return retVal;
        }
    }
}
