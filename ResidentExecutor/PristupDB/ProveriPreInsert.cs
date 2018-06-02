using Contract;
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
        private string selectUpit1 = "SELECT * FROM FunkcijaAverage";
        private string selectUpit2 = "SELECT * FROM FunkcijaMaximum";
        private string selectUpit3 = "SELECT * FROM FunkcijaMinimum";

        public Dictionary<string, List<CalculationTable>> PosaljiInsert()
        {
            List<CalculationTable> retVal2 = new List<CalculationTable>();
            Dictionary<string, List<CalculationTable>> retVal = new Dictionary<string, List<CalculationTable>>();

            #region IscitavanjeIzTabeleFunkcijaAverage
            Polja.conn.Open();
            SqlCommand cmd = new SqlCommand(selectUpit1, Polja.conn);
            SqlDataReader reader = cmd.ExecuteReader();

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
            cmd = new SqlCommand(selectUpit2, Polja.conn);
            reader = cmd.ExecuteReader();

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
            cmd = new SqlCommand(selectUpit3, Polja.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                retVal2.Add(new CalculationTable((string)reader.GetSqlString(0),
                                                reader.GetSqlDateTime(1),
                                                (double)reader.GetSqlDouble(2),
                                                reader.GetSqlDateTime(4)));
            retVal.Add("MIN", retVal2);
            retVal2 = new List<CalculationTable>();
            reader.Close();
            Polja.conn.Close();
            #endregion

            return retVal;
        }
    }
}
