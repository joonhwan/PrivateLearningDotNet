using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FaultReport.Service
{
    [ServiceContract]
    public interface IOneWayService
    {
        //[OperationContract(IsOneWay = true)]
        //[FaultContract(typeof(ArgumentException))]

        [OperationContract(IsOneWay = true)]
        void TestOperation();
    }
}
