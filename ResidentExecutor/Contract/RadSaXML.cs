using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    public class RadSaXML
    {
        private string putanja = @"../../../rezidentne_funkcije.xml";
        private string putanjaGeoPodrucja = "../../../geo_podrucja.xml";
        public List<FUNKCIJA> CitajIzXML()
        {
            List<FUNKCIJA> retVal = new List<FUNKCIJA>();
            XmlSerializer desrializer = new XmlSerializer(typeof(List<FUNKCIJA>), new XmlRootAttribute("REZIDENTNE_FUNKCIJE"));

            using (TextReader reader = new StreamReader(putanja))
            {
                object obj = desrializer.Deserialize(reader);
                retVal = (List<FUNKCIJA>)obj;
            }

            return retVal;
        }
        public List<GeoPodrucja> CitajIzXMLGeoPodrucja()
        {
            List<GeoPodrucja> retVal = new List<GeoPodrucja>();
            XmlSerializer desrializer = new XmlSerializer(typeof(List<GeoPodrucja>), new XmlRootAttribute("GEOGRAFSKA_PODRUCJA"));

            using (TextReader reader = new StreamReader(putanjaGeoPodrucja))
            {
                object obj = desrializer.Deserialize(reader);
                retVal = (List<GeoPodrucja>)obj;
            }
            return retVal;
        }
    }
}
