using Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupDB
{
    public class GetSelectQuery : IGetSelectQuery
    {
        public string GetFromUneseneVrednosti()
        {
            return "SELECT * FROM UneseneVrednosti";
        }

        public string GetFromUneseneVrednostiDate()
        {
            return "SELECT * FROM UneseneVrednosti WHERE CONVERT(DATE, VremeMerenja) = CONVERT(DATE, GETDATE())";
        }

        public string GetFromFunkcijaAverage()
        {
            return "SELECT * FROM FunkcijaAverage";
        }

        public string GetFromFunkcijaMaximum()
        {
            return "SELECT * FROM FunkcijaMaximum";
        }

        public string GetFromFunkcijaMinimum()
        {
            return "SELECT * FROM FunkcijaMinimum";
        }
    }
}
