using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    public class OperationReportInspector : IParameterInspector
    {
        private readonly string _serviceName;

        public OperationReportInspector(ServiceDescription serviceDescription)
        {
            _serviceName = serviceDescription.Name;
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }

        // correlationState 는 BeforeCall()이 반환한 값.
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            var serviceName = _serviceName; //this.GetType().Name;
            System.Console.WriteLine("{0} - '{1}.{2}' operation called.", DateTime.Now.ToLongDateString(), serviceName, operationName);
        }
    }
}