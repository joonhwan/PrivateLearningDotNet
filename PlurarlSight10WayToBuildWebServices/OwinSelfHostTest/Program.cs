using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace OwinSelfHostTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controll"
                );
        }
    }
}
