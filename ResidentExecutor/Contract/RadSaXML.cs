﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    public class RadSaXML : IXml
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

        public void NapraviXMLFunkcije()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<FUNKCIJA>), new XmlRootAttribute("REZIDENTNE_FUNKCIJE"));

            List<FUNKCIJA> lista = new List<FUNKCIJA>()
            {
                new FUNKCIJA() { ID = 1, UKLJUCENO = 1 },
                new FUNKCIJA() { ID = 2, UKLJUCENO = 1 },
                new FUNKCIJA() { ID = 3, UKLJUCENO = 0 }
            };

            using (TextWriter write = new StreamWriter(putanja))
            {
                xml.Serialize(write, lista);
            }
        }

        public void IzmeniXML()
        {
            Random random = new Random();
            List<FUNKCIJA> lista = CitajIzXML();

            foreach (var item in lista)
                item.UKLJUCENO = random.Next(2);

            XmlSerializer serializer = new XmlSerializer(typeof(List<FUNKCIJA>), new XmlRootAttribute("REZIDENTNE_FUNKCIJE"));
            using (TextWriter writer = new StreamWriter(putanja))
            {
                serializer.Serialize(writer, lista);
            }
        }

        public void NapraviXMLGeoPOdrucja()
        {
            List<GeoPodrucja> lista = new List<GeoPodrucja>();
            XmlSerializer xml = new XmlSerializer(typeof(List<GeoPodrucja>), new XmlRootAttribute("GEOGRAFSKA_PODRUCJA"));

            foreach (var item in GeoPodrucja.geoPodrucja)
                lista.Add(new GeoPodrucja(item.Key, item.Value));

            using (TextWriter write = new StreamWriter("../../../geo_podrucja.xml"))
            {
                xml.Serialize(write, lista);
            }
        }
    }
}
