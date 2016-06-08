using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    public class OperationReportOperationBehavior : IOperationBehavior
    {
        private OperationReportInspector _inspector;

        public OperationReportOperationBehavior(ServiceDescription serviceDescription)
        {
            _inspector = new OperationReportInspector(serviceDescription);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            var methodName = operationDescription.Name;
            dispatchOperation.ParameterInspectors.Add(_inspector);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }
    }
}