using System.ServiceModel;

namespace FaultReport.Service
{
    public class OneWayClient : ClientBase<IOneWayService>, IOneWayService
    {
        public OneWayClient()
        {
            
        }
        public void TestOperation()
        {
            Channel.TestOperation();
        }
    }
}