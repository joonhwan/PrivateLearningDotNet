using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WebSocketNotifier.Service
{
    [ServiceContract]
    public interface INotifierService
    {
        [OperationContract(IsOn]
        void Notify(Message msg);
    }
}