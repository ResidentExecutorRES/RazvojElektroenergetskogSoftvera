using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    [XmlRoot("REZIDENTNE_FUNKCIJE")]
    [DataContract]
    public class FUNKCIJA
    {
        public FUNKCIJA()
        {
        }

        public FUNKCIJA(int i, int u)
        {
            if (i > 3 || i < 1)
                throw new ArgumentOutOfRangeException();
            if (u > 1 || u < 0)
                throw new ArgumentOutOfRangeException();
            
            ID = i;
            UKLJUCENO = u;
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UKLJUCENO { get; set; }
    }
}
