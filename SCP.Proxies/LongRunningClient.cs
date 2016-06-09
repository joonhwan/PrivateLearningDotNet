using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SCP.Contracts;

namespace SCP.Proxies
{
    public class LongRunningClient : ClientBase<ILongRunningService>, ILongRunningService
    {
        public void StartProcess()
        {
            base.Channel.StartProcess();
        }
    }
}
