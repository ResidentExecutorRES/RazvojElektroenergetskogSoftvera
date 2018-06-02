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
        private static ChannelFactory<IDanasnjiDatum> factoryDanasnji = null;
        private static ChannelFactory<IProveriPreInsert> factoryPreInserta = null;

        private static IDanasnjiDatum proxyDanasnji = null;
        private static IProveriPreInsert proxyProveriPreInserta = null;

        private static List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> listaUbacenihVrednostiWhile;

        static void Main(string[] args)
        {
            Connect();

            while (true)
            {
                listaUbacenihVrednostiWhile = new List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>>();
                List<PodaciIzBaze> podaci = proxyDanasnji.DanasnjiDatum();
                listaUbacenihVrednostiWhile.Add(Automatic(podaci));

                foreach (var item in listaUbacenihVrednostiWhile)
                {
                    foreach (var item1 in item)
                    {
                        Console.WriteLine(item1.Key.Item1 + " " + item1.Key.Item2 + " " + item1.Value.Item1 + " " + item1.Value.Item2);
                    }
                }

                List<string> uBazu = InsertIntoTable(listaUbacenihVrednostiWhile);
                DuplexSample(uBazu);
                podaci = new List<PodaciIzBaze>();

                Thread.Sleep(20000);
            }
        }
        public static void Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            string addressDanasnjiDatum = "net.tcp://localhost:10103/IDanasnjiDatum";
            string addressInsert = "net.tcp://localhost:10105/IProveriPreInsert";

            factoryDanasnji = new ChannelFactory<IDanasnjiDatum>(binding,new EndpointAddress(addressDanasnjiDatum));
            factoryPreInserta = new ChannelFactory<IProveriPreInsert>(binding,new EndpointAddress(addressInsert));

            proxyDanasnji = factoryDanasnji.CreateChannel();
            proxyProveriPreInserta = factoryPreInserta.CreateChannel();
        }
        public static void Disconnect()
        {
            proxyDanasnji = null;
            factoryDanasnji.Close();

            proxyProveriPreInserta = null;
            factoryPreInserta.Close();
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
        public static List<string> InsertIntoTable(List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> listaUbacenihVrednostiWhile)
        {
            List<string> retVal = new List<string>();
            List<PodaciIzBaze> traziDatum = proxyDanasnji.DanasnjiDatum().OrderByDescending(o => o.ID).ThenBy(n => n.Vreme).ToList();
            List<PodaciIzBaze> traziNajnovijiDatum = SamoPoJednoPodrucje(traziDatum);

            foreach (var itemDatum in traziNajnovijiDatum)
            {
                foreach (var itemLista in listaUbacenihVrednostiWhile)
                {
                    foreach (var itemDict in itemLista)
                    {
                        if (itemDict.Key.Item1 == 1 && itemDatum.ID == itemDict.Key.Item2 && 
                            (ProveriZaIf(itemDict.Key.Item2, SqlDateTime.Parse(itemDatum.Vreme.ToString()), itemDict.Key.Item1)))
                                retVal.Add("INSERT INTO FunkcijaAverage (IDGeoPodrucja, VremeProracuna, AverageVrednost, PoslednjeVreme) " +
                                    "VALUES ('" + itemDict.Key.Item2 + "'," +
                                    "'" + SqlDateTime.Parse(itemDict.Value.Item1.ToString()) + "'," +
                                    itemDict.Value.Item2 + "," +
                                    "'" + SqlDateTime.Parse(itemDatum.Vreme.ToString()) + "')");

                        else if (itemDict.Key.Item1 == 2 && itemDatum.ID == itemDict.Key.Item2 && 
                            (ProveriZaIf(itemDict.Key.Item2, SqlDateTime.Parse(itemDatum.Vreme.ToString()), itemDict.Key.Item1)))
                                retVal.Add("INSERT INTO FunkcijaMaximum (IDGeoPodrucja, VremeProracuna, MaximalnaVrednost, PoslednjeVreme) " +
                                    "VALUES ('" + itemDict.Key.Item2 + "'," +
                                    "'" + SqlDateTime.Parse(itemDict.Value.Item1.ToString()) + "'," +
                                    itemDict.Value.Item2 + "," +
                                    "'" + SqlDateTime.Parse(itemDatum.Vreme.ToString()) + "')");

                        else if (itemDict.Key.Item1 == 3 && itemDatum.ID == itemDict.Key.Item2 && 
                            (ProveriZaIf(itemDict.Key.Item2, SqlDateTime.Parse(itemDatum.Vreme.ToString()), itemDict.Key.Item1)))
                                retVal.Add("INSERT INTO FunkcijaMinimum (IDGeoPodrucja, VremeProracuna, MinimalnaVrednost, PoslednjeVreme) " +
                                    "VALUES ('" + itemDict.Key.Item2 + "'," +
                                    "'" + SqlDateTime.Parse(itemDict.Value.Item1.ToString()) + "'," +
                                    itemDict.Value.Item2 + "," +
                                    "'" + SqlDateTime.Parse(itemDatum.Vreme.ToString()) + "')");
                    }
                }
            }
            
            return retVal;
        }
        public static bool ProveriZaIf(string id, SqlDateTime vreme, int i)
        {
            bool retVal = true;
            string spojeno = id + vreme.ToString();            
            Dictionary<string, List<CalculationTable>> proxyLista = proxyProveriPreInserta.PosaljiInsert();

            foreach (var item in proxyLista)
            {
                foreach (var item2 in item.Value)
                {
                    if (i == 1 && item.Key == "AVG" && (item2.Id + item2.PoslednjeVreme.ToString().ToString()) == spojeno)
                    {
                        retVal = false;
                        break;
                    }
                    else if (i == 2 && item.Key == "MAX" && (item2.Id + item2.PoslednjeVreme.ToString().ToString()) == spojeno)
                    {
                        retVal = false;
                        break;
                    }
                    else if (i == 3 && item.Key == "MIN" && (item2.Id + item2.PoslednjeVreme.ToString().ToString()) == spojeno)
                    {
                        retVal = false;
                        break;
                    }
                }
            }

            return retVal;
        }
        public static List<PodaciIzBaze> SamoPoJednoPodrucje(List<PodaciIzBaze> listaDatuma)
        {
            List<PodaciIzBaze> retVal = listaDatuma;
            int i = 0;
            while (i < retVal.Count - 1)
            {
                if (retVal[i].ID == retVal[i + 1].ID)
                    retVal.RemoveAt(i);
                else
                    i++;
            }

            return retVal;
        }
        private static void DuplexSample(List<string> lista)
        {
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress address = new EndpointAddress("net.tcp://localhost:10104/IInsertCulculationFunction");

            var clientCallback = new UpisiCallback2();
            var context = new InstanceContext(clientCallback);
            var factory = new DuplexChannelFactory<IInsertCulculationFunction>(clientCallback, binding, address);

            IInsertCulculationFunction messageChanel = factory.CreateChannel();
            Task.Run(() => messageChanel.PosaljiInsert(lista));
        }
    }
}
