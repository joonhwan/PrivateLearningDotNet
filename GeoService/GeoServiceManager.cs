using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading;

namespace GeoService
{
    [ServiceBehavior]
    [ArgumentExceptionHandler]
    //[OperationReportServiceBehavior]
    public class GeoServiceManager : IGeoService, IServiceBehavior
    {
        public GeoInfo GetGeoInfoByZipCode(int zipCode)
        {
            if(zipCode>2)
            {
                // throw new ArgumentException(); //--> 이렇게 하면 Unahndled Exception. 통신도 Fault상태가 되버린다.

                //// 그래서.. FauleException을 사용해서 throw 해야 하는데.... 그것도 IErrorHandler를 사용시에는 다시 원래 방법(-_-) 대로 한다.
                //var e = new ArgumentException(@"too big zip code !!!")
                //throw new FaultException<ArgumentException>(e); // SOAP friendly Exception Handling

                throw new ArgumentException(@"too big zip code !!!");
            }

            return new GeoInfo()
            {
                AreaName = string.Format("Area of {0}", zipCode),
            };
        }

        //[OperationReportOperationBehavior(true)]
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

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var endpoint in serviceDescription.Endpoints)
            {
                if (endpoint.Contract.ContractType == typeof(IGeoService))
                {
                    foreach (var operation in endpoint.Contract.Operations)
                    {
                        if (operation.Name == "GetGeoInfoByZipCode"
                            && !operation.Faults.Any(description => description.DetailType == typeof(ArgumentException)))
                        {
                            throw new InvalidOperationException("GetGeoInfoByZipCode operation require a fault contract of ArgumentException");
                        }
                    }
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}