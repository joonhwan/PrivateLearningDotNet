using System;
using System.IO;
using System.Reflection;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.TinyIoc;

namespace NancyFoodJournalApp.OwinSelfHost
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        //protected override IRootPathProvider RootPathProvider
        //{
        //    get { return new ServiceRootPathProvider(); }
        //}

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

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //base.ApplicationStartup(container, pipelines);
            StaticConfiguration.EnableRequestTracing = true; // 이걸 하면 tracing이 가능해진다.
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("scripts"));
            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("fonts"));
        }
    }

    public class ServiceRootPathProvider : IRootPathProvider
    {
        //private readonly IRootPathProvider _provider = new DefaultRootPathProvider();

        public string GetRootPath()
        {
            //return Path.GetFullPath(Path.Combine(_provider.GetRootPath(), "..", ".."));

            var assembly =
                Assembly.GetEntryAssembly() ??
                Assembly.GetExecutingAssembly();

            var assemblyPath =
                Path.GetDirectoryName(assembly.Location) ??
                Environment.CurrentDirectory; // Windows service인 경우 안될껄.

            var rootPath =
                Path.GetFullPath(Path.Combine(assemblyPath, "..", ".."));

            return rootPath; ;
        }
    }
}