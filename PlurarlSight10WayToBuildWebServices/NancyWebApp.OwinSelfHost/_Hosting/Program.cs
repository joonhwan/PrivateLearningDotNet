using System;
using Microsoft.Owin.Hosting;

namespace NancyWebApp.OwinSelfHost.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:1234";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running...");
                Console.ReadLine();
            }
        }
    }
}
