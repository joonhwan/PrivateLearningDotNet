using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using SCP.Contracts;

namespace SCP.Proxies
{
    //public class LongRunningClient : ClientBase<ILongRunningService>, ILongRunningService
    //{
    //    public void StartProcess()
    //    {
    //        base.Channel.StartProcess();
    //    }
    //}

    public class LongRunningDuplexClient : DuplexClientBase<ILongRunningService>, ILongRunningService
    {
        public LongRunningDuplexClient(ILongRunningCallback sink)
            : base(new InstanceContext(sink))
        {

        }

        public void Connect()
        {
            Channel.Connect();
        }

        public void Disconnect()
        {
            Channel.Disconnect();
        }

        public void StartProcess()
        {
            base.Channel.StartProcess();
        }
    }
}
