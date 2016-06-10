using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FaultReport.Service
{
    [ServiceContract(CallbackContract = typeof(IOneWayExceptionCallback))]
    public interface IOneWayService
    {
        //[OperationContract(IsOneWay = false)]
        //[FaultContract(typeof(ArgumentException))]

        [OperationContract(IsOneWay = true)]
        void TestOperation();
    }
}
