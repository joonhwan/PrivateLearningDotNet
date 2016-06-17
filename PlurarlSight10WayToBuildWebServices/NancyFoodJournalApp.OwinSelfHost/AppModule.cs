using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace NancyFoodJournalApp.OwinSelfHost
{
    public class AppModule : NancyModule
    {
        public AppModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}
