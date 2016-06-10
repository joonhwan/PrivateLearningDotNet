using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FaultReport.Service;

namespace FaultReport.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(OneWayManager));
            host.Open();
            Console.WriteLine("Service is running.. press Enter key to exit");
            Console.ReadLine();
            host.Close();
        }
    }
}
