namespace SignalRMyHub
{
    public interface IMyHubServer
    {
        void Send(string name, string message);
    }
}