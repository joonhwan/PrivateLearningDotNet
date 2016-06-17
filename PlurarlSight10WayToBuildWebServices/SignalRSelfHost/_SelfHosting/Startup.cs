using Microsoft.Owin.Cors;
using Nancy;
using Owin;

namespace SignalRSelfHost._SelfHosting
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); // 이 프로그램에서 웹사이트를 제공하지 않으면 CORS 필요.
            app.MapSignalR();
            app.UseNancy();
        }
    }

    public class AppModule : NancyModule
    {
        public AppModule()
        {
            Get["/"] = _ => View["main.html"];
        }
    }
}