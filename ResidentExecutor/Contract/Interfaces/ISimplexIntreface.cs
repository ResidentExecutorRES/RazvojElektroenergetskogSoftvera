using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IDanasnjiDatum
    {
        [OperationContract]
        List<PodaciIzBaze> DanasnjiDatum();
    }

    [ServiceContract]
    public interface IProveriPreInsert
    {
        [OperationContract]
        Dictionary<string, List<CalculationTable>> PosaljiInsert();
    }

    [ServiceContract]
    public interface IConnect
    {
        [OperationContract]
        List<PodaciIzBaze> VratiRedove();
    }
}
