using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Routing;
using System.Text;
using System.Threading.Tasks;

namespace WcfRoutingCbr.RoutingHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var routingHost = new ServiceHost(typeof(RoutingService));
            foreach (var endpoint in routingHost.Description.Endpoints)
            {
                Console.WriteLine("{0} ({1})", endpoint.Address, endpoint.Contract.ContractType);
            }
            routingHost.Open();

            Console.WriteLine("Routing service is running...press enter key to exit");
            Console.ReadLine();
            routingHost.Close();
        }
    }
}
