using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorisnickiInterfejs
{
    public class UpisiCallback : IUpisiCallback
    {
        public void OnCallback(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            Console.WriteLine("Message from server, {0}.", message);
        }
    }
}
