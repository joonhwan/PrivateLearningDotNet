using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using SignalRMyHub;

namespace SignalRSelfHost._SelfHosting
{
    // http://www.asp.net/signalr/overview/deployment/tutorial-signalr-self-host
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:28080";
            using (WebApp.Start<Startup>(url))
            {
                var cancelled = false;
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    cancelled = true;
                };
                Console.WriteLine("Server running on {0}", url);

                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                while(!cancelled)
                {
                    Thread.Sleep(5000);
                    context.Clients.All.addMessage("system", string.Format("Current time : {0}", DateTime.Now.ToString("u")));
                }
            }
        }
    }
}
