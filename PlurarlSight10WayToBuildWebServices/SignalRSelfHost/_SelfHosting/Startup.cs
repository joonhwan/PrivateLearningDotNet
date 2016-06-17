using Microsoft.Owin.Cors;
using Nancy;
using Owin;

namespace SignalRSelfHost._SelfHosting
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); // �� ���α׷����� ������Ʈ�� �������� ������ CORS �ʿ�.
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