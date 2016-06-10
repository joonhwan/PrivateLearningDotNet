using System;
using System.ServiceModel;
using WcfCors;

namespace PunService.AJAX.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new CorsEnabledServiceHost(typeof(PunManager));
            foreach(var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine("Endpoint:{0}({1})", endpoint.Address, endpoint.Contract.ContractType);
            }
            host.Open();
            Console.WriteLine("Running...press any key to exit...");
            Console.ReadLine();
            host.Close();
        }
    }
}
