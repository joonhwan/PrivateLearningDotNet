using System;
using System.Collections.Generic;
using System.ServiceModel;
using SCP.Contracts;

namespace SCP.Services
{
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)] //--> 이걸 계속 쓰려면 lock 필요
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LongRunningManager : ILongRunningService
    {
        private static readonly Dictionary<string, RandomNumberGeneratingJob> Jobs = new Dictionary<string, RandomNumberGeneratingJob>();

        public LongRunningManager()
        {
        }

        public void Connect()
        {
            var session = OperationContext.Current.SessionId;
            if (session == null)
            {
                return;
            }

            var callback = OperationContext.Current.GetCallbackChannel<ILongRunningCallback>();
            
            var job = new RandomNumberGeneratingJob(callback);
            var channel = OperationContext.Current.Channel;
            channel.Closed += (sender, args) =>
            {
                job.Stop();
            };
            Jobs[session] = job;
            
        }

        public void Disconnect()
        {
            var session = OperationContext.Current.SessionId;
            if (session == null)
                return;

            RandomNumberGeneratingJob job;
            if(Jobs.TryGetValue(session, out job))
            {
                job.Stop();
                Jobs.Remove(session);
            }
        }

        public void StartProcess()
        {
            var sessionId = OperationContext.Current.SessionId;
            if(sessionId == null)
            {
                return;
            }

            RandomNumberGeneratingJob job;
            if(Jobs.TryGetValue(sessionId, out job))
            {
                job.Start();
            }
        }
    }

    
}