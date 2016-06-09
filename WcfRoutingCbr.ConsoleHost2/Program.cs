using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfRoutingCbr.Service;

namespace WcfRoutingCbr.ConsoleHost2
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(GeoManager2));
            host.Open();
            Console.WriteLine("ConsoleHost v2.0 - Press any key to exit");
            Console.ReadLine();
            host.Close();
        }
    }
}
