using System;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;

namespace SignalR_PersistentConnection_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:28081";
            using (WebApp.Start(url))
            {
                var cancelled = false;
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    cancelled = true;
                };
                Console.WriteLine("Server running on {0}", url);
                Thread.Sleep(-1);

            }
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); // 이 프로그램에서 웹사이트를 제공하지 않으면 CORS 필요.
            app.MapSignalR<MyConnection>("/echo");
        }
    }

    public class MyConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Console.WriteLine("OnConnected: {0}", connectionId);
            return base.OnConnected(request, connectionId);
        }

        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            Console.WriteLine("OnReconnected: {0}", connectionId);
            return base.OnReconnected(request, connectionId);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Console.WriteLine("OnReceived: {0}", connectionId);
            Console.WriteLine("  --> received : {0}", data);

            return Connection.Broadcast(data);
            //return base.OnReceived(request, connectionId, data);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Console.WriteLine("OnDisconnected : {0}", connectionId);
            return base.OnDisconnected(request, connectionId, stopCalled);
        }
    }
}
