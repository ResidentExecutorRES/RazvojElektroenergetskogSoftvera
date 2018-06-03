using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Exceptions
{
    public class VremeException : Exception
    {
        public VremeException(string message) : base(message) { }
        public VremeException() : this("Nevalidno vreme ...") { }
    }
}
