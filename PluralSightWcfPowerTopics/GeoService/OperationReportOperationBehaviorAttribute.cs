using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class OperationReportOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        public bool Enabled { get; private set; }

        public event EventHandler<OperationInformationEventArgs> ServiceOperationCalled;

        public OperationReportOperationBehaviorAttribute(bool enabled)
        {
            Enabled = enabled;
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            if (Enabled)
            {
                var methodName = operationDescription.Name;
                var serviceName = dispatchOperation.Parent.Type.Name;
                var inspector = new OperationReportInspector(serviceName);

                inspector.ServiceOperationCalled += (sender, args) =>
                {
                    OnServiceOperationCalled(args);
                };
                dispatchOperation.ParameterInspectors.Add(inspector);
            }
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }

        protected virtual void OnServiceOperationCalled(OperationInformationEventArgs e)
        {
            var handler = ServiceOperationCalled;
            if (handler != null) handler(this, e);
        }
    }
}