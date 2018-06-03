using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Contract.Exceptions;

namespace Contract
{
    [DataContract]
    public class CalculationTable
    {
        public CalculationTable(string id, SqlDateTime vremeProracuna, double vrednost, SqlDateTime poslednjeVreme)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException();
            if (vrednost < 0 || vrednost >= Double.MaxValue)
                throw new ArgumentOutOfRangeException();
            if (vremeProracuna >(SqlDateTime)DateTime.Now || poslednjeVreme > (SqlDateTime)DateTime.Now)
                throw new VremeException();
            
            Id = id;
            VremeProracuna = vremeProracuna;
            Vrednost = vrednost;
            PoslednjeVreme = poslednjeVreme;
        }

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public SqlDateTime VremeProracuna { get; set; }
        [DataMember]
        public double Vrednost { get; set; }
        [DataMember]
        public SqlDateTime PoslednjeVreme { get; set; }
    
    }
}
