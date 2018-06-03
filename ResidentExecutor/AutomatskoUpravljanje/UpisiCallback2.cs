using Contract;
using System;

namespace AutomatskoUpravljanje
{
    public class UpisiCallback2 : IUpisiCallback2
    {
        public void OnCallback(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            Console.WriteLine("Message from server, {0}.", message);
        }
    }
}
