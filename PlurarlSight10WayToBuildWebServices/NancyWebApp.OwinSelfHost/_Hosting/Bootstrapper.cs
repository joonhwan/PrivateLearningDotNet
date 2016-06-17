using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using Nancy.ViewEngines;

namespace NancyWebApp.OwinSelfHost._Hosting
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                return new DiagnosticsConfiguration
                {
                    Password = "admin",
                };
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //This should be the assembly your views are embedded in
            var assembly = GetType().Assembly;
            var rootNamespaces = ResourceViewLocationProvider.RootNamespaces;
            // TODO: replace NancyEmbeddedViews.MyViews with your resource prefix
            //.Add(assembly, "NancyEmbeddedViews.MyViews");
            rootNamespaces.Add(assembly, "NancyWebApp.OwinSelfHost");
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder);
            }
        }

        void OnConfigurationBuilder(NancyInternalConfiguration x)
        {
            x.ViewLocationProvider = typeof(ResourceViewLocationProvider);
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //base.ApplicationStartup(container, pipelines);
            StaticConfiguration.EnableRequestTracing = true; // 이걸 하면 tracing이 가능해진다.

            // view의 위치가 app/view/ 폴더에 있도록 하려면...다른 많은 convention에 이걸 추가.
            Conventions.ViewLocationConventions.Insert(0, (viewName, model, context) => string.Concat("app/views/", viewName));
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
        }
    }
}