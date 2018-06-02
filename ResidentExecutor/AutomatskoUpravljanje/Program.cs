using Contract;
using KorisnickiInterfejs;
using PristupDB;
using ServisniSloj;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatskoUpravljanje
{
    class Program
    {
        private static List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> listaUbacenihVrednostiWhile;

        static void Main(string[] args)
        {
            ObradaPodatakaZaDB obrada = new ObradaPodatakaZaDB();
            while (true)
            {
                obrada.Connect();

                listaUbacenihVrednostiWhile = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
                List<PodaciIzBaze> podaci = obrada.proxyDanasnji.DanasnjiDatum();
                listaUbacenihVrednostiWhile.Add(Automatic(podaci));

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

                Thread.Sleep(20000);
            }
        }
        public static Dictionary<Tuple<int, string>, Tuple<DateTime, float>> Automatic(List<PodaciIzBaze> podaci)
        {
            ICalculationFunctions f = new CalculationFunctions();
            List<int> listaIDFunkcija = ObradaPodataka.GetIDFunkcija();
            Dictionary<string, List<float>> vrednostiZaOdredjenoPodrucje = ObradaPodataka.GetVrijednostiZaGeoPodrucje(podaci);
            Dictionary<Tuple<int, string>, Tuple<DateTime, float>> retVal = new Dictionary<Tuple<int, string>, Tuple<DateTime, float>>();

            foreach (var item1 in listaIDFunkcija)
            {
                foreach (var item2 in vrednostiZaOdredjenoPodrucje)
                {
                    if (item1 == 1)
                        retVal.Add(new Tuple<int, string>(1, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Average(item2.Value)));
                    else if (item1 == 2)
                        retVal.Add(new Tuple<int, string>(2, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Maximum(item2.Value)));
                    else
                        retVal.Add(new Tuple<int, string>(3, item2.Key), new Tuple<DateTime, float>(DateTime.Now, f.Minimum(item2.Value)));
                }
            }

            return retVal;
        }
    }
}
