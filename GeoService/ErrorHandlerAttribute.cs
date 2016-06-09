using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace GeoService
{
    public class ErrorHandlerAttribute : Attribute, IErrorHandler
    {
        // �� � service�� operation ���� �߻��� ��� exception�� �߻��ϸ� ����� �´�?
        // ProvideFault�� Client�� �޽����� �ϴ� ���߿� ȣ��ȴ�. ���⼭ ó���ð��� �������, ���� ����ð��� �������?
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is ArgumentException)
            {
                // �׸��� �Ʒ��� ���� sleep�ϸ�, client������ ����޽��� ���� �����̰� �����.(���� ���۷��̼��� ó���ϴ� ���� �����忡�� ó��)
                //Thread.Sleep(5000);
                var faultException = new FaultException<ArgumentException>(new ArgumentException(error.Message));// �׳� error as ArgumentException�� �ѱ�� �̻��� ������ �߻�. -_-
                fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
            }
            else
            {
                // �Ʒ� ó�� fault = null �ϸ�, client �ʿ����� channel fault���� ���ܰ� �߻��Ѵ�.
                // ���ܰ� �߻��ϸ�, ���ä�ο� ������ ����ٴ� ����� �ر� ����.
                fault = null;// 
            }
        }

        // �� � service�� operation ���� �߻��� ��� exception�� �߻��� ���� ����� ���µ� �ٸ� Thread���� ȣ��ȴ�?
        // --> ����, ���� �߻��� DB�� �α� ���, Email ���۵� �ð��� �ɸ��� ���� ó���� ���⼭ �����ϵ��� �Ѵ�.
        public bool HandleError(Exception error)
        {
            return true; // ���⼭ false�� ��ȯ�ϸ�, Session �� ������.
        }
    }
}