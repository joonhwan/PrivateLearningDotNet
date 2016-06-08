using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    [ServiceBehavior()]
    public class GeoServiceManager : IGeoService, IServiceBehavior, IOperationBehavior, IParameterInspector
    {
        public GeoServiceManager()
        {
            
        }

        public GeoInfo GetGeoInfoByZipCode(int zipCode)
        {
            return new GeoInfo()
            {
                AreaName = string.Format("Area of {0}", zipCode),
            };
        }

        public List<ZipCode> GetZipCodes()
        {
            return new List<ZipCode>
            {
                new ZipCode{ Code = 1, State = "Yongin" },
                new ZipCode{ Code = 2, State = "Suwon" },
                new ZipCode{ Code = 3, State = "Seoul" },
                new ZipCode{ Code = 4, State = "Bundang" },
                new ZipCode{ Code = 5, State = "Daejoen" },
                new ZipCode{ Code = 6, State = "Busan" },
            };
        }

        // IServiceBehavior ----

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            foreach (var endpoint in serviceDescription.Endpoints)
            {
                foreach (var operation in endpoint.Contract.Operations)
                {
                    operation.OperationBehaviors.Add(this);
                }
            }
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        // IOperationBehavior ----

        public void Validate(OperationDescription operationDescription)
        {   
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            var methodName = operationDescription.Name;
            dispatchOperation.ParameterInspectors.Add(this);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            
        }

        // IParameterInspector

        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }

        // correlationState 는 BeforeCall()이 반환한 값.
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            System.Console.WriteLine("{0} - '{1}.{2}' operation called.", DateTime.Now.ToLongDateString(), this.GetType().Name, operationName);
        }
    }
}