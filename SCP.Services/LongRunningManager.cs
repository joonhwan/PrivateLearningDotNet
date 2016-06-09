using System;
using System.Collections.Generic;
using System.Threading;
using SCP.Contracts;

namespace SCP.Services
{
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
            for(var i=0; i<100; ++i)
            {
                var gen = random.Next();
                Console.WriteLine("Generated {0}", gen);

                _numbers.Add(gen);

                Thread.Sleep(3000);
            }
        }
    }
}