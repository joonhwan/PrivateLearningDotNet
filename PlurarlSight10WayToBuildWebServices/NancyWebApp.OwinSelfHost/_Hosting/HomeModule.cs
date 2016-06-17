using Nancy;

namespace NancyWebApp.OwinSelfHost.Hosting
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index"];
            Get["/home"] = _ => View["home"];
        }
    }
}