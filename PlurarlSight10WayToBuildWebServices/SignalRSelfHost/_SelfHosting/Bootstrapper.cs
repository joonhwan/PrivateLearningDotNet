using System;
using System.IO;
using System.Reflection;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.Diagnostics.Modules;
using Nancy.Responses;
using Nancy.Session;
using Nancy.TinyIoc;
using Nancy.ViewEngines;

namespace SignalRSelfHost._SelfHosting
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private string _resourceNamespace;
        private Assembly _assembly;

        public Bootstrapper()
        {
            //_assembly = Assembly.GetAssembly(typeof(MainModule));
            _assembly = GetType().Assembly;
            if (string.IsNullOrEmpty(_resourceNamespace))
            {
                //fallback.
                _resourceNamespace = Path.GetFileNameWithoutExtension(_assembly.Location) + ".Views";
            }
        }

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
            var rootNamespaces = ResourceViewLocationProvider.RootNamespaces;
            // TODO: replace NancyEmbeddedViews.MyViews with your resource prefix
            //.Add(assembly, "NancyEmbeddedViews.MyViews");

            rootNamespaces.Add(_assembly, _resourceNamespace);
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
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Add(AddStaticResourcePath("/app", _assembly, _resourceNamespace + ".app"));
            nancyConventions.StaticContentsConventions.Add(AddStaticResourcePath("/jspm_packages/npm", _assembly, _resourceNamespace + ".etc"));
        }

        public static Func<NancyContext, string, Response> AddStaticResourcePath(string requestedPath, Assembly assembly, string namespacePrefix)
        {
            return (context, s) =>
            {
                var path = context.Request.Path;
                if (!path.StartsWith(requestedPath))
                {
                    return null;
                }

                string resourcePath;
                string name;

                var adjustedPath = path.Length > 1 ? path.Substring(requestedPath.Length + 1) : path;
                if (adjustedPath.IndexOf('/') >= 0)
                {
                    name = Path.GetFileName(adjustedPath);
                    if (adjustedPath == "/")
                    {
                        resourcePath = namespacePrefix;
                    }
                    else
                    {
                        resourcePath = namespacePrefix + "." + adjustedPath.Substring(0, adjustedPath.Length - name.Length - 1).Replace('/', '.');
                    }
                }
                else
                {
                    name = adjustedPath;
                    resourcePath = namespacePrefix;
                }
                return new EmbeddedFileResponse(assembly, resourcePath, name);
            };
        }
    }
}