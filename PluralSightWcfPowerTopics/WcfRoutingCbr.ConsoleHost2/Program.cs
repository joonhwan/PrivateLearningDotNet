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
            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("{0} ({1})", endpoint.Address, endpoint.Contract.ContractType);
            }
            host.Open();
            Console.WriteLine("ConsoleHost v2.0 - Press any key to exit");
            Console.ReadLine();
            host.Close();
        }
    }
}
