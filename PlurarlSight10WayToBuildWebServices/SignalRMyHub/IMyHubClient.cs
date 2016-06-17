using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRMyHub
{
    public interface IMyHubClient
    {
        void AddMessage(string name, string message);
    }
}