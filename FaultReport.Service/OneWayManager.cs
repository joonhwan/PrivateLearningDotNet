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

                var ex = new ArgumentException("This is my arg exception");
                //throw new FaultException<ArgumentException>(ex, ex.Message);
                throw ex;

                Console.WriteLine("Exiting  OneWayManager");
            }
            catch (Exception ex)
            {
                var callback = OperationContext.Current.GetCallbackChannel<IOneWayExceptionCallback>();
                if(callback!=null)
                {
                    callback.ReportError(ex);
                }
                //throw;
            }
        }
    }
}