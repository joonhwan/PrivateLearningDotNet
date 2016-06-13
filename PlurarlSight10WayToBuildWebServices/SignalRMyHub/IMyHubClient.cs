namespace SignalRMyHub
{
    public interface IMyHubClient
    {
        void addMessage(string name, string message);
    }
}