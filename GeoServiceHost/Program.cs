using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(GeoService.GeoService));
            host.Open();

            Console.WriteLine("Running Host...press any key to exit.");
            Console.ReadLine();
        }
    }
}
