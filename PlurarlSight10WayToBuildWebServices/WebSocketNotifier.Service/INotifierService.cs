using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WebSocketNotifier.Service
{
    [ServiceContract]
    public interface INotifierService
    {
        [OperationContract]
        void Notify(Message msg);
    }
}