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

        // client���� ȣ���� �� �ִ� 'Server Method' (Ŭ���̾� javascript���� send('myname', 'this is a message') �� ȣ��
        public void Send(string name, string message)
        {
            Console.WriteLine("Server Method Called : Send({0}, {1})", name, message);

            // server method������ Context �Ӽ����� ���� ȣ�����ؽ�Ʈ�� �� �� �ִ�.

            // server���� ȣ���� �� �ִ� 'Client Method' (Ŭ���̾�Ʈ javascript���� ����)
            Clients.All.AddMessage(name, message);
        }

        // ���⼭ WCF�� ���� ��� ȣ���� �� �� �ִ�. 

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