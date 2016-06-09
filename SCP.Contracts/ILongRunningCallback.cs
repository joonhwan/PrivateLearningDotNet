using System.ServiceModel;

namespace SCP.Contracts
{
    [ServiceContract]
    public interface ILongRunningCallback
    {
        [OperationContract] // IsOneway가 아님! 반환값 있음.
        bool ReportNumber(int number);
    }
}