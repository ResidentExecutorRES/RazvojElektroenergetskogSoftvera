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
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UKLJUCENO { get; set; }
    }
}
