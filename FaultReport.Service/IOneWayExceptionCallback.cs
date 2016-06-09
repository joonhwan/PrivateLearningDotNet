using System;
using System.ServiceModel;

namespace FaultReport.Service
{
    [ServiceContract]
    public interface IOneWayExceptionCallback
    {
        [OperationContract]
        void ReportError(Exception ex);
    }
}