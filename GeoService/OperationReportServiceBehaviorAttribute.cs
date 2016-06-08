using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace GeoService
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationReportServiceBehaviorAttribute : Attribute, IServiceBehavior
    {
        public bool Enabled { get; private set; }

        public event EventHandler<OperationInformationEventArgs> ServiceOperationCalled;

        public OperationReportServiceBehaviorAttribute(bool enabled)
        {
            Enabled = enabled;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            if (Enabled)
            {
                foreach (var endpoint in serviceDescription.Endpoints)
                {
                    foreach (var operation in endpoint.Contract.Operations)
                    {
                        var operationBehavior = new OperationReportOperationBehaviorAttribute(Enabled);
                        operationBehavior.ServiceOperationCalled += (sender, args) =>
                        {
                            OnServiceOperationCalled(args);
                        };
                        operation.OperationBehaviors.Add(operationBehavior);
                    }
                }
            }
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        protected virtual void OnServiceOperationCalled(OperationInformationEventArgs e)
        {
            var handler = ServiceOperationCalled;
            if (handler != null) handler(this, e);
        }
    }
}