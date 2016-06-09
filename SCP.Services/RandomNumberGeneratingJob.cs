using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using SCP.Contracts;

namespace SCP.Services
{
    public class RandomNumberGeneratingJob
    {
        private List<int> _numbers;
        public bool StopRequested { get; private set; }
        public ILongRunningCallback Callback { get; private set; }

        public RandomNumberGeneratingJob(ILongRunningCallback callback)
        {
            _numbers = new List<int>();
            StopRequested = false;
            Callback = callback;
        }

        public void Start()
        {
            Task.Run(() =>
            {
                DoJob();
            });
        }

        public void Stop()
        {
            StopRequested = false;
        }

        private void DoJob()
        {
            var callback = Callback;
            var random = new Random();
            var isCancelled = false;
            for (var i = 0; i < 100; ++i)
            {
                var gen = random.Next();
                Console.WriteLine("Generated {0}", gen);

                _numbers.Add(gen);

                if (callback != null)
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
                if (isCancelled || StopRequested)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
        }
    }
}