using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WcfCors
{
    public class CorsConfiguration
    {
        protected CorsConfiguration()
        {
        }

        public static CorsConfiguration Instance = new CorsConfiguration();
    }

    public interface ICorsConfigurationProvider
    {
        CorsDomain FindByDomainName(string origin);
    }

    class CorsEnabledMessageInspector : IDispatchMessageInspector
    {
        private ICorsConfigurationProvider _corsConfigurationProvider;

        public CorsEnabledMessageInspector(ICorsConfigurationProvider corsConfigurationProvider)
        {
            _corsConfigurationProvider = corsConfigurationProvider;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var httpRequest = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            return new
            {
                origin = httpRequest.Headers["Origin"],
                handlePreflight = httpRequest.Method.Equals("OPTIONS", StringComparison.InvariantCultureIgnoreCase)
            };
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var state = (dynamic)correlationState;

            CorsDomain domain = _corsConfigurationProvider.FindByDomainName(state.origin);
            if (domain != null)
            {
                // handle request preflight
                if (state.handlePreflight)
                {
                    reply = Message.CreateMessage(MessageVersion.None, "PreflightReturn");

                    var httpResponse = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);

                    httpResponse.SuppressEntityBody = true;
                    httpResponse.StatusCode = HttpStatusCode.OK;
                }

                // add allowed origin info
                var response = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                response.Headers.Add("Access-Control-Allow-Origin", state.origin);

                if (!string.IsNullOrEmpty(domain.AllowMethods))
                    response.Headers.Add("Access-Control-Allow-Methods", domain.AllowMethods);

                if (!string.IsNullOrEmpty(domain.AllowHeaders))
                    response.Headers.Add("Access-Control-Allow-Headers", domain.AllowHeaders);

                if (domain.AllowCredentials)
                    response.Headers.Add("Access-Control-Allow-Credentials", "true");
            }
        }
    }
}
