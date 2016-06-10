using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    public class OperationReportInspector : IParameterInspector
    {
        private readonly string _serviceName;
        public event EventHandler<OperationInformationEventArgs> ServiceOperationCalled;

        public OperationReportInspector(string serviceName)
        {
            _serviceName = serviceName;
        }

        public object BeforeCall(string operationName, object[] inputs)
        {

            return null;
        }

        // correlationState 는 BeforeCall()이 반환한 값.
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            //var serviceName = _serviceName; //this.GetType().Name;
            //System.Console.WriteLine("{0} - '{1}.{2}' operation called.", DateTime.Now.ToLongDateString(), serviceName, operationName);
            OnServiceOperationCalled(new OperationInformationEventArgs
            {
                OperationName = operationName,
                ServiceName = _serviceName,
                TimeStamp = DateTime.Now,
            });
        }

        protected virtual void OnServiceOperationCalled(OperationInformationEventArgs e)
        {
            var handler = ServiceOperationCalled;
            if (handler != null) handler(this, e);
        }
    }
}