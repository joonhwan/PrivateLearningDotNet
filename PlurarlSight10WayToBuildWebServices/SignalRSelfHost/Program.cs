using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;

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
                    Thread.Sleep(1000);
                    context.Clients.All.addMessage("system", string.Format("Current time : {0}", DateTime.Now.ToString("u")));
                }
                Console.ReadLine();
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

    public class MyHub : Hub
    {
        public MyHub()
        {
            Console.WriteLine("MyHub has been created.");
        }

        // client에서 호출할 수 있는 'Server Method' (클라이언 javascript에서 send('myname', 'this is a message') 로 호출
        public void Send(string name, string message)
        {
            // server에서 호출할 수 있는 'Client Method' (클라이언트 javascript에서 정의)
            Clients.All.addMessage(name, message);
        }

        // 여기서 WCF로 가는 모든 호출을 할 수 있다. 

        public override Task OnConnected()
        {
            Console.WriteLine("MyHub.OnConnected() : {0}", Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("MyHub.OnDisconnected({0}) : {1}", stopCalled, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("MyHub.OnReconnected() : {0}", Context.ConnectionId);
            return base.OnReconnected();
        }
    }
}
