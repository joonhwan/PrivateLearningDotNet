using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SCP.Contracts;
using SCP.Services;

namespace SCP.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(LongRunningManager));
            host.Open();

            Console.WriteLine("Service is runnning...press Enter key to exit");
            Console.ReadLine();

            host.Close();
        }
    }
}
