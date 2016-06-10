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
    // http://therealmofcode.com/posts/2015/05/wcf-enabling-cors.html
    // https://github.com/zminic/wcf-cors-support
    class CorsEnabledEndpointBehavior : BehaviorExtensionElement, IEndpointBehavior, ICorsConfigurationProvider
    {
        public CorsEnabledEndpointBehavior()
        {
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
                AllowHeaders = "X-Requested-With,Content-Type",
                AllowMethods = "POST,GET,PUT,DELETE,OPTIONS"
            };
        }
    }
}