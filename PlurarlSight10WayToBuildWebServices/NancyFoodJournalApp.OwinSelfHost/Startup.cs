using Owin;

namespace NancyFoodJournalApp.OwinSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}