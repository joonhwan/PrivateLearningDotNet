using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using SignalRMyHub;

namespace SignalRSelfHost
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
            using (WebApp.Start(url))
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

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); // 이 프로그램에서 웹사이트를 제공하지 않으면 CORS 필요.
            app.MapSignalR();
        }
    }
}
