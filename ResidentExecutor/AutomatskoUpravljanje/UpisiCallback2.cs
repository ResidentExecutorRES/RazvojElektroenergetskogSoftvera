using Contract;
using System;

namespace AutomatskoUpravljanje
{
    public class UpisiCallback2 : IUpisiCallback2
    {
        public void OnCallback(string message)
        {
            Console.WriteLine("Message from server, {0}.", message);
        }
    }
}
