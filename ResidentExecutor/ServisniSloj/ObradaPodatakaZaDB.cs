using Contract;
using Contract.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServisniSloj
{
    public class ObradaPodatakaZaDB
    {

        public ChannelFactory<IDanasnjiDatum> factoryDanasnji = null;
        public ChannelFactory<IProveriPreInsert> factoryPreInserta = null;

        public IDanasnjiDatum proxyDanasnji = null;
        public IProveriPreInsert proxyProveriPreInserta = null;

        public void Connect()
        {
            NetTcpBinding binding = new NetTcpBinding();

            string addressDanasnjiDatum = "net.tcp://localhost:10103/IDanasnjiDatum";
            string addressInsert = "net.tcp://localhost:10105/IProveriPreInsert";

            factoryDanasnji = new ChannelFactory<IDanasnjiDatum>(binding, new EndpointAddress(addressDanasnjiDatum));
            factoryPreInserta = new ChannelFactory<IProveriPreInsert>(binding, new EndpointAddress(addressInsert));

            proxyDanasnji = factoryDanasnji.CreateChannel();
            proxyProveriPreInserta = factoryPreInserta.CreateChannel();
        }

        public List<string> InsertIntoTable(List<Dictionary<Tuple<int, string>, Tuple<DateTime, float>>> listaUbacenihVrednostiWhile)
        {
            #region CatchExceptions

            if (listaUbacenihVrednostiWhile == null)
                throw new ArgumentNullException();

            foreach (var item in listaUbacenihVrednostiWhile)
            {
                if (item == null)
                    throw new ArgumentNullException();
                foreach (var itemDict in item)
                {
                    if (itemDict.Value == null || itemDict.Key == null)
                        throw new ArgumentNullException();

                    if (itemDict.Key.Item1 < 1 || itemDict.Key.Item1 > 3)
                        throw new ArgumentOutOfRangeException();
                    if (String.IsNullOrEmpty(itemDict.Key.Item2))
                        throw new ArgumentNullException();

                    if (itemDict.Value.Item1 > DateTime.Now)
                        throw new VremeException();
                    if (itemDict.Value.Item2 >= float.MaxValue || itemDict.Value.Item2 < 0)
                        throw new ArgumentOutOfRangeException();
                }
            }
            #endregion

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

        public bool ProveriZaIf(string id, SqlDateTime vreme, int i)
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

        public List<PodaciIzBaze> SamoPoJednoPodrucje(List<PodaciIzBaze> listaDatuma)
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

        public void DuplexSample(List<string> lista)
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

    public class UpisiCallback2 : IUpisiCallback2
    {
        public void OnCallback(string message)
        {
            Console.WriteLine("Message from server, {0}.", message);
        }
    }
}
