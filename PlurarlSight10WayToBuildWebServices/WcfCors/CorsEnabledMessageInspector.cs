﻿using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WcfCors
{
    class CorsEnabledMessageInspector : IDispatchMessageInspector
    {
        private readonly List<string> _corsEnabledOperationNames;

        public CorsEnabledMessageInspector(List<OperationDescription> corsEnabledOperations)
        {
            this._corsEnabledOperationNames = corsEnabledOperations.Select(o => o.Name).ToList();
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            HttpRequestMessageProperty httpProp = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            object operationName;
            request.Properties.TryGetValue(WebHttpDispatchOperationSelector.HttpOperationNamePropertyName, out operationName);
            if (httpProp != null && operationName != null && this._corsEnabledOperationNames.Contains((string)operationName))
            {
                string origin = httpProp.Headers[CorsConstants.Origin];
                if (origin != null)
                {
                    return origin;
                }
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            string origin = correlationState as string;
            if (origin != null)
            {
                HttpResponseMessageProperty httpProp = null;
                if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    httpProp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                }
                else
                {
                    httpProp = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name, httpProp);
                }

                httpProp.Headers.Add(CorsConstants.AccessControlAllowOrigin, origin);
            }
        }
    }
}
