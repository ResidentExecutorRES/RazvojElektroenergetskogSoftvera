using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    [DataContract]
    public class GeoPodrucja
    {
        public static readonly Dictionary<string, string> geoPodrucja = new Dictionary<string, string>()
        {
            { "BL", "Banjaluka"},
            { "BN", "Bijeljina"},
            { "DO", "Doboj"},
            { "PR", "Prnjavor"},
            { "SA", "Sarajevo"},
            { "TR", "Trebinje"},
            { "ZV", "Zvornik"},
            { "GR", "Gradiska"},
            { "BI", "Bihac"},
            { "MO", "Mostar" }
        };
        public GeoPodrucja() { }
        public GeoPodrucja(string id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }        

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Naziv { get; set; }       

        public void NapraviXMLGeoPOdrucja()
        {
            List<GeoPodrucja> lista = new List<GeoPodrucja>();
            XmlSerializer xml = new XmlSerializer(typeof(List<GeoPodrucja>), new XmlRootAttribute("GEOGRAFSKA_PODRUCJA"));
            
            foreach (var item in geoPodrucja)
                lista.Add(new GeoPodrucja(item.Key, item.Value));      

            using (TextWriter write = new StreamWriter("../../../geo_podrucja.xml"))
            {
                xml.Serialize(write, lista);
            }
        }
    }
}
