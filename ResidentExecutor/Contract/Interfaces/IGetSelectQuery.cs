using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interfaces
{
    public interface IGetSelectQuery
    {
        string GetFromUneseneVrednosti();
        string GetFromUneseneVrednostiDate();
        string GetFromFunkcijaAverage();
        string GetFromFunkcijaMaximum();
        string GetFromFunkcijaMinimum();
    }
}
