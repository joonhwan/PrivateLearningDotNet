using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace NancyFoodJournalApp.OwinSelfHost
{
    class Program
    {
        private static readonly ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var port = 8090;
            if(args.Length > 0)
            {
                int.TryParse(args[0], out port);
            }

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                _quitEvent.Set();
                eventArgs.Cancel = true;
            };

            var uri = string.Format("http://*:{0}", port);
            using(WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started : {0}", uri);
                _quitEvent.WaitOne();
            }
        }
    }
}
