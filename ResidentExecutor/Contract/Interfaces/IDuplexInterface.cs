using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    #region IInsertCulculationFunctionDuplex
    public interface IUpisiCallback2
    {
        [OperationContract(IsOneWay = true)]
        void OnCallback(string message);
    }

    [ServiceContract(CallbackContract = typeof(IUpisiCallback2))]
    public interface IInsertCulculationFunction
    {
        [OperationContract]
        void PosaljiInsert(List<string> insertInto);
    }
    #endregion

    #region IUpisiDuplex
    public interface IUpisiCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCallback(string message);
    }

    [ServiceContract(CallbackContract = typeof(IUpisiCallback))]
    public interface IUpisi
    {
        [OperationContract]
        void PosaljiInsert(string insertInto);
    }
    #endregion

}
