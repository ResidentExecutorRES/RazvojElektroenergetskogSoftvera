using Contract;
using Contract.Exceptions;
using ServisniSloj;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutomatskoUpravljanje
{
    class Program
    {
        
        private static List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> listaUbacenihVrednostiWhile;
        private static readonly GetValues obr = new GetValues();
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 20);
            ObradaPodatakaZaDB obrada = new ObradaPodatakaZaDB();
            Automatik a = new Automatik();
            obrada.Connect();

            while (true)
            {                
                listaUbacenihVrednostiWhile = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
                List<PodaciIzBaze> podaci = obrada.proxyDanasnji.DanasnjiDatum();
                listaUbacenihVrednostiWhile.Add(a.Automatic(podaci));
                Console.WriteLine("Izvrsene funkije...");
                List<string> uBazu = obrada.InsertIntoTable(listaUbacenihVrednostiWhile);
                obrada.DuplexSample(uBazu);
                podaci = new List<PodaciIzBaze>();
                Console.WriteLine();
                Thread.Sleep(10000);
            }
        }        
    }
}
