using System.IO;
using Nancy;
using Nancy.Hosting.Wcf;

namespace NancyWebApp.WcfSelfHost
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new ServiceRootPathProvider(); }
        }


    }

    public class ServiceRootPathProvider : IRootPathProvider
    {
        private readonly IRootPathProvider _provider = new FileSystemRootPathProvider();

        public string GetRootPath()
        {
            return Path.GetFullPath(Path.Combine(_provider.GetRootPath(), "..", ".."));
        }
    }
}