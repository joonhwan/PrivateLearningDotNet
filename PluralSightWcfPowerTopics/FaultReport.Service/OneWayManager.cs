using System;
using System.ServiceModel;
using System.Threading;

namespace FaultReport.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class OneWayManager : IOneWayService
    {
        public void TestOperation()
        {
            try
            {
                Console.WriteLine("Entering OneWayManager");
                //Thread.Sleep(4000);

                //var ex = new ArgumentException("This is my arg exception");
                //throw new FaultException<ArgumentException>(ex, ex.Message);
                throw new ArgumentException("This is my arg exception");

                Console.WriteLine("Exiting  OneWayManager");
            }
            catch (Exception ex)
            {
                var callback = OperationContext.Current.GetCallbackChannel<IOneWayExceptionCallback>();
                if(callback!=null)
                {
                    // 그냥 ex를 전달하면 serialization 오류가 발생하는 데 왜 그런지 알 수가 없다.
                    //callback.ReportError(new ArgumentException(ex.Message));
                    callback.ReportError(ex);
                }
                //throw;
            }
        }
    }
}