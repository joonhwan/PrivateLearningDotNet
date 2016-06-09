using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCP.Contracts
{
    [ServiceContract]
    public interface ILongRunningService
    {
        [OperationContract(IsOneWay = true)]
        void StartProcess();
    }
}
