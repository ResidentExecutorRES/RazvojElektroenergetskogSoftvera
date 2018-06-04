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
        private static GetValues obr = new GetValues();
        static void Main(string[] args)
        {
            ObradaPodatakaZaDB obrada = new ObradaPodatakaZaDB();
            Automatik a = new Automatik();
            obrada.Connect();

            while (true)
            {               
                
                Console.WriteLine("--------------------------------------------------------------------------------");
                listaUbacenihVrednostiWhile = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
                List<PodaciIzBaze> podaci = obrada.proxyDanasnji.DanasnjiDatum();
                listaUbacenihVrednostiWhile.Add(a.Automatic(podaci));

                foreach (var item in listaUbacenihVrednostiWhile)
                {
                    foreach (var item1 in item)
                    {
                        Console.WriteLine(item1.Key.Item1 + " " + item1.Key.Item2 + " " + item1.Value.Item1 + " " + item1.Value.Item2);
                    }
                }

                List<string> uBazu = obrada.InsertIntoTable(listaUbacenihVrednostiWhile);
                obrada.DuplexSample(uBazu);
                podaci = new List<PodaciIzBaze>();
                Console.WriteLine();
                Thread.Sleep(10000);
            }
        }
        //public static Dictionary<Tuple<int, string>, Tuple<DateTime, float>> Automatic(List<PodaciIzBaze> podaci)
        //{
        //    if (podaci == null)
        //        throw new ArgumentNullException();

        //    foreach (var item in podaci)
        //    {
        //        if (String.IsNullOrEmpty(item.ID))
        //            throw new ArgumentNullException();
        //        if (item.Vrednost < 0 || item.Vrednost > float.MaxValue)
        //            throw new ArgumentOutOfRangeException();
        //        if (item.Vreme > DateTime.Now)
        //            throw new VremeException();
        //    }

        //    ICalculationFunctions f = new CalculationFunctions();
        //    List<int> listaIDFunkcija = obr.GetIDFunkcija();            
            
        //    Dictionary<string, List<float>> vrednostiZaOdredjenoPodrucje = obr.GetVrijednostiZaGeoPodrucje(podaci);
        //    Dictionary<Tuple<int, string>, Tuple<DateTime, float>> retVal = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>();

        //    foreach (var item1 in listaIDFunkcija)
        //    {
        //        foreach (var item2 in vrednostiZaOdredjenoPodrucje)
        //        {
        //            if (item1 == 1)
        //                retVal.Add(new Tuple<int, string>(1, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Average(item2.Value)));
        //            else if (item1 == 2)
        //                retVal.Add(new Tuple<int, string>(2, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Maximum(item2.Value)));
        //            else if (item1 == 3)
        //                retVal.Add(new Tuple<int, string>(3, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Minimum(item2.Value)));
        //            else
        //                throw new FormatException();
        //        }
        //    }

        //    return retVal;
        //}
    }
}
