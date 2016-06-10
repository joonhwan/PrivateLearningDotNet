using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ArgumentExceptionHandlerAttribute : Attribute, IServiceBehavior
    {
        // �� ���񽺰� ���ϴ� ������� �����Ǿ����� Ȯ���� �� �ִ�.
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {

        }

        // Channep�� ����ɶ� ȣ��ȴ�? --> Error Handler�� ChannelDispatcher�� ��ġ�ؾ� �Ѵ�. 
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var item in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = item as ChannelDispatcher;
                if (channelDispatcher == null)
                {
                    continue;
                }

                channelDispatcher.ErrorHandlers.Add(new ErrorHandlerAttribute());
            }
        }
    }

    public class ArgumentExceptionHandlerExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new ArgumentExceptionHandlerAttribute();
        }

        public override Type BehaviorType
        {
            get { return typeof(ArgumentExceptionHandlerAttribute); }
        }
    }
}