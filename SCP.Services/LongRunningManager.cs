using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using SCP.Contracts;

namespace SCP.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LongRunningManager : ILongRunningService
    {
        private List<int> _numbers;

        public LongRunningManager()
        {
            _numbers = new List<int>();
        }

        public void StartProcess()
        {
            var random = new Random();

            var isCancelled = false;
            var operationContext = OperationContext.Current;
            var callback = operationContext.GetCallbackChannel<ILongRunningCallback>();

            for(var i=0; i<100; ++i)
            {
                var gen = random.Next();
                Console.WriteLine("Generated {0}", gen);

                _numbers.Add(gen);

                if(callback != null)
                {
                    try
                    {
                        isCancelled = callback.ReportNumber(gen);
                    }
                    catch (CommunicationException)
                    {
                        // 클라이언트 종료 되면 예외발생한다. 
                        isCancelled = true;
                    }
                }
                if (isCancelled)
                {
                    break;
                }
                Thread.Sleep(3000);
            }
        }
    }
}