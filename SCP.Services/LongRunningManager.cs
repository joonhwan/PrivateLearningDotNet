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
            for(var i=0; i<100; ++i)
            {
                var gen = random.Next();
                Console.WriteLine("Generated {0}", gen);

                _numbers.Add(gen);

                var callback = OperationContext.Current.GetCallbackChannel<ILongRunningCallback>();
                if(callback != null)
                {
                    isCancelled = callback.ReportNumber(gen);
                }
                //if (isCancelled)
                //{
                //    break;
                //}
                Thread.Sleep(3000);
            }
        }
    }
}