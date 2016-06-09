using System;
using System.Threading;

namespace FaultReport.Service
{
    public class OneWayManager : IOneWayService
    {
        public void TestOperation()
        {
            Console.WriteLine("Entering OneWayManager");
            Thread.Sleep(4000);
            Console.WriteLine("Exiting  OneWayManager");
        }
    }
}