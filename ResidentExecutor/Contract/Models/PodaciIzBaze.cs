using Contract.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [DataContract]
    public class PodaciIzBaze
    {
        public PodaciIzBaze(string iD, SqlDateTime vreme, float vrednost)
        {
            if(String.IsNullOrEmpty(iD))
                throw new ArgumentNullException();
            if(vrednost < 0 || vrednost >= float.MaxValue)
                throw new ArgumentOutOfRangeException();
            if (vreme > (SqlDateTime)DateTime.Now)
                throw new VremeException();

            ID = iD;
            Vreme = vreme;
            Vrednost = vrednost;
        }

        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public SqlDateTime Vreme { get; set; }
        [DataMember]
        public float Vrednost { get; set; }
    }
}
