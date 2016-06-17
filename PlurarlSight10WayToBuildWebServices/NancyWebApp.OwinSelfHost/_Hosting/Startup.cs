using Owin;

namespace NancyWebApp.OwinSelfHost.Hosting
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseNancy();
        }
    }
}