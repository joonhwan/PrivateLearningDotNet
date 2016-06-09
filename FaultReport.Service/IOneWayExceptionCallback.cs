using System;
using System.ServiceModel;

namespace FaultReport.Service
{
    [ServiceContract]
    public interface IOneWayExceptionCallback
    {
        [OperationContract]
        [ServiceKnownType(typeof(ArgumentException))]
        void ReportError(ArgumentException ex);
    }
}