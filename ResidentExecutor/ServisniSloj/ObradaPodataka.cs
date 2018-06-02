using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PristupDB;

namespace ServisniSloj
{
    public class ObradaPodataka
    {
        public static Dictionary<string, List<float>> GetVrijednostiZaGeoPodrucje(List<PodaciIzBaze> podaci)
        {
            List<float> ret2 = new List<float>();
            Dictionary<string, List<float>> ret = new Dictionary<string, List<float>>();

            foreach (var item1 in GetIDGeoPodrucja())
            {
                foreach (var item2 in podaci)
                {
                    if (item1 == item2.ID)
                        ret2.Add(item2.Vrednost);
                }
                ret.Add(item1, ret2);
                ret2 = new List<float>();
            }          
            
            return ret;
        }
        public static  List<int> GetIDFunkcija()
        {
            List<int> listaID = new List<int>();
            foreach (var item in (new RadSaXML().CitajIzXML()))
            {
                if (item.UKLJUCENO == 1)
                    listaID.Add(item.ID);
            }

            return listaID;
        }

        public static List<string> GetIDGeoPodrucja()
        {
            List<string> listaID = new List<string>();
            foreach (var item in (new RadSaXML().CitajIzXMLGeoPodrucja()))
                listaID.Add(item.Id);

            return listaID;
        }
    }
}
