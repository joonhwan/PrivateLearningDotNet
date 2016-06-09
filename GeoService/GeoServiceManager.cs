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
                // throw new ArgumentException(); //--> �̷��� �ϸ� Unahndled Exception. ��ŵ� Fault���°� �ǹ�����.

                //// �׷���.. FauleException�� ����ؼ� throw �ؾ� �ϴµ�.... �װ͵� IErrorHandler�� ���ÿ��� �ٽ� ���� ���(-_-) ��� �Ѵ�.
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

        // �� � service�� operation ���� �߻��� ��� exception�� �߻��ϸ� ����� �´�?
        // ProvideFault�� Client�� �޽����� �ϴ� ���߿� ȣ��ȴ�. ���⼭ ó���ð��� �������, ���� ����ð��� �������?
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if(error is ArgumentException)
            {
                // �Ʒ� ó�� fault = null �ϸ�, client �ʿ����� channel fault���� ���ܰ� �߻��Ѵ�.���ܰ� �߻��ϸ�, ���ä�ο� ������ ����ٴ� ����� �ر� ����.
                //fault = null;
                //return;


                // �׸��� �Ʒ��� ���� sleep�ϸ�, client������ ����޽��� ���� �����̰� �����.(���� ���۷��̼��� ó���ϴ� ���� �����忡�� ó��)
                //Thread.Sleep(5000);
                var faultException = new FaultException<ArgumentException>(new ArgumentException(error.Message));// �׳� error as ArgumentException�� �ѱ�� �̻��� ������ �߻�. -_-
                fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
            }
        }

        // �� � service�� operation ���� �߻��� ��� exception�� �߻��� ���� ����� ���µ� �ٸ� Thread���� ȣ��ȴ�?
        // --> ����, ���� �߻��� DB�� �α� ���, Email ���۵� �ð��� �ɸ��� ���� ó���� ���⼭ �����ϵ��� �Ѵ�.
        public bool HandleError(Exception error)
        {
            return true; // ���⼭ false�� ��ȯ�ϸ�, Session �� ������.
        }

        // �� ���񽺰� ���ϴ� ������� �����Ǿ����� Ȯ���� �� �ִ�.
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

        // Channep�� ����ɶ� ȣ��ȴ�? --> Error Handler�� ChannelDispatcher�� ��ġ�ؾ� �Ѵ�. 
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