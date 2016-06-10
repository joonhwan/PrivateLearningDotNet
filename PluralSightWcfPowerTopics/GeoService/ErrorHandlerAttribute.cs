using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    public class ErrorHandlerAttribute : Attribute, IErrorHandler
    {
        // 그 어떤 service의 operation 에서 발생한 모든 exception이 발생하면 여기로 온다?
        // ProvideFault는 Client의 메시지을 하는 도중에 호출된다. 여기서 처리시간이 길어지면, 서비스 응답시간도 길어진다?
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is ArgumentException)
            {
                // 그리고 아래와 같이 sleep하면, client측에서 응답메시지 수신 딜레이가 생긴다.(서비스 오퍼레이션을 처리하는 동일 쓰레드에서 처리)
                //Thread.Sleep(5000);
                var faultException = new FaultException<ArgumentException>(new ArgumentException(error.Message));// 그냥 error as ArgumentException을 넘기면 이상한 오류가 발생. -_-
                fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
            }
            else
            {
                // 아래 처럼 fault = null 하면, client 쪽에서는 channel fault상태 예외가 발생한다.
                // 예외가 발생하면, 통신채널에 문제가 생긴다는 사실을 잊기 쉽다.
                fault = null;// 
            }
        }

        // 그 어떤 service의 operation 에서 발생한 모든 exception이 발생한 다음 여기로 오는데 다른 Thread에서 호출된다?
        // --> 따라서, 오류 발생시 DB에 로그 기록, Email 전송등 시간이 걸리는 오류 처리는 여기서 수행하도록 한다.
        public bool HandleError(Exception error)
        {
            return true; // 여기서 false를 반환하면, Session 이 닫힌다.
        }
    }
}