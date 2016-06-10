using System.ServiceModel;

namespace FaultReport.Service
{
    public class OneWayClient : DuplexClientBase<IOneWayService>, IOneWayService
    {
        public OneWayClient(IOneWayExceptionCallback sink)
            : base(new InstanceContext(sink))
        {
            
        }
        public void TestOperation()
        {
            Channel.TestOperation();
        }
    }
}