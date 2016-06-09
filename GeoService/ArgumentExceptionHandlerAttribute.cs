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
        // 이 서비스가 원하는 방식으로 설정되었는지 확인할 수 있다.
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {

        }

        // Channep이 연결될때 호출된다? --> Error Handler는 ChannelDispatcher에 설치해야 한다. 
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