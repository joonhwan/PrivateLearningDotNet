using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRMyHub
{
    //[HubName("MyHub")]
    public class MyHub : Hub<IMyHubClient>, IMyHubServer
    {
        public MyHub()
        {
            Console.WriteLine("MyHub has been created.");
        }

        // client에서 호출할 수 있는 'Server Method' (클라이언 javascript에서 send('myname', 'this is a message') 로 호출
        public void Send(string name, string message)
        {
            Console.WriteLine("Server Method Called : Send({0}, {1})", name, message);

            // server method에서는 Context 속성으로 현재 호출컨텍스트를 알 수 있다.

            // server에서 호출할 수 있는 'Client Method' (클라이언트 javascript에서 정의)
            Clients.All.AddMessage(name, message);
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