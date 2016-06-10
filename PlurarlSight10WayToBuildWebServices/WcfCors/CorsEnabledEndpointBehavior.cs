using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfCors
{
    class CorsEnabledEndpointBehavior : BehaviorExtensionElement, IEndpointBehavior, ICorsConfigurationProvider
    {
        public CorsEnabledEndpointBehavior()
        {
            // https://github.com/zminic/wcf-cors-support/tree/master/SampleAjaxService
            // https://github.com/zminic/wcf-cors-support/blob/master/SampleAjaxService/App.config
            //var config = ConfigurationManager.GetSection("customSettings") as CustomSettings;

            //if (config == null)
            //    throw new InvalidOperationException("Missing CORS configuration");

            //var domain = config.CorsSupport.OfType<CorsDomain>().FirstOrDefault(d => d.Name == state.origin);
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CorsEnabledMessageInspector(this));
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        protected override object CreateBehavior()
        {
            return new CorsEnabledEndpointBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(CorsEnabledEndpointBehavior); }
        }

        public CorsDomain FindByDomainName(string origin)
        {
            return new CorsDomain()
            {
                Filter = "*",
                AllowCredentials = false,
                AllowHeaders = "Content-Type",
                AllowMethods = "POST,GET,PUT,DELETE,OPTIONS"
            };
        }
    }
}