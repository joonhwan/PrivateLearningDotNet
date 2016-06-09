using System;
using System.ServiceModel;
using System.Threading;

namespace FaultReport.Service
{
    public class OneWayManager : IOneWayService
    {
        public void TestOperation()
        {
            Console.WriteLine("Entering OneWayManager");
            Thread.Sleep(4000);

            var ex = new ArgumentException("This is my arg exception");
            throw new FaultException<ArgumentException>(ex, ex.Message);

            Console.WriteLine("Exiting  OneWayManager");
        }
    }
}