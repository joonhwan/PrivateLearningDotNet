using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Wcf;

namespace NancyWebApp.WcfSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:1234";
            var host = new WebServiceHost(typeof(NancyWcfGenericService), new Uri(uri));

            host.AddServiceEndpoint(typeof(NancyWcfGenericService), new WebHttpBinding(), "");

            host.Open();

            Console.WriteLine("Running..press any key to exit");

            Console.ReadLine();

            host.Close();
        }
    }
}
