using Contract;
using KorisnickiInterfejs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PristupDB
{
    class Program
    {
        private static ServiceHost svc = null;
        private static ServiceHost svcUpisi = null;
        private static ServiceHost svcInsertList = null;
        private static ServiceHost svcDanasnjiDatum = null;
        private static ServiceHost svcProveriPreInsert = null;

        static void Main(string[] args)
        {
            Open();
            while (true)
            {            
                Thread.Sleep(1000);
            }
        }
        public static void Open()
        {
            svc = new ServiceHost(typeof(Connect));
            svcUpisi = new ServiceHost(typeof(Upisi));
            svcDanasnjiDatum = new ServiceHost(typeof(Konekcija));
            svcInsertList = new ServiceHost(typeof(InsertCaluculationFunction));
            svcProveriPreInsert = new ServiceHost(typeof(ProveriPreInsert));

            svc.AddServiceEndpoint(typeof(IConnect), new NetTcpBinding(), "net.tcp://localhost:10100/IConnect");
            svcUpisi.AddServiceEndpoint(typeof(IUpisi), new NetTcpBinding(), "net.tcp://localhost:10102/IUpisi");
            svcDanasnjiDatum.AddServiceEndpoint(typeof(IDanasnjiDatum), new NetTcpBinding(), "net.tcp://localhost:10103/IDanasnjiDatum");
            svcInsertList.AddServiceEndpoint(typeof(IInsertCulculationFunction), new NetTcpBinding(), "net.tcp://localhost:10104/IInsertCulculationFunction");
            svcProveriPreInsert.AddServiceEndpoint(typeof(IProveriPreInsert), new NetTcpBinding(), "net.tcp://localhost:10105/IProveriPreInsert");

            svc.Open();
            svcUpisi.Open();
            svcInsertList.Open();
            svcDanasnjiDatum.Open();
            svcProveriPreInsert.Open();

            Console.WriteLine("Server is started...");
        }
        public static void Close()
        {
            svc.Close();
            svcUpisi.Close();
            svcInsertList.Close();
            svcDanasnjiDatum.Close();
            svcProveriPreInsert.Close();

            Console.WriteLine("Server is stopped...");
        }     
    }
}
