using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace GeoService
{
    [ServiceBehavior()]
    //[OperationReportServiceBehavior]
    public class GeoServiceManager : IGeoService, IErrorHandler, IServiceBehavior
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

        // 그 어떤 service의 operation 에서 발생한 모든 exception이 발생하면 여기로 온다?
        // ProvideFault는 Client의 메시지을 하는 도중에 호출된다. 여기서 처리시간이 길어지면, 서비스 응답시간도 길어진다?
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if(error is ArgumentException)
            {
                // 아래 처럼 fault = null 하면, client 쪽에서는 channel fault상태 예외가 발생한다.예외가 발생하면, 통신채널에 문제가 생긴다는 사실을 잊기 쉽다.
                //fault = null;
                //return;


                // 그리고 아래와 같이 sleep하면, client측에서 응답메시지 수신 딜레이가 생긴다.(서비스 오퍼레이션을 처리하는 동일 쓰레드에서 처리)
                //Thread.Sleep(5000);
                var faultException = new FaultException<ArgumentException>(new ArgumentException(error.Message));// 그냥 error as ArgumentException을 넘기면 이상한 오류가 발생. -_-
                fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
            }
        }

        // 그 어떤 service의 operation 에서 발생한 모든 exception이 발생한 다음 여기로 오는데 다른 Thread에서 호출된다?
        // --> 따라서, 오류 발생시 DB에 로그 기록, Email 전송등 시간이 걸리는 오류 처리는 여기서 수행하도록 한다.
        public bool HandleError(Exception error)
        {
            return true; // 여기서 false를 반환하면, Session 이 닫힌다.
        }

        // 이 서비스가 원하는 방식으로 설정되었는지 확인할 수 있다.
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach(var endpoint in serviceDescription.Endpoints)
            {
                if(endpoint.Contract.ContractType == typeof(IGeoService))
                {
                    foreach(var operation in endpoint.Contract.Operations)
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

        // Channep이 연결될때 호출된다? --> Error Handler는 ChannelDispatcher에 설치해야 한다. 
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach(var item in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = item as ChannelDispatcher;
                if(channelDispatcher == null)
                {
                    continue; 
                }

                channelDispatcher.ErrorHandlers.Add(this);
            }
        }
    }
}