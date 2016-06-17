using System;
using Nancy;
using Nancy.Conventions;

namespace SignalRSelfHost._SelfHosting
{
    public class ResourceStaticContentProvider : IStaticContentProvider
    {
        private readonly IRootPathProvider rootPathProvider;
        private readonly StaticContentsConventions conventions;
        private string rootPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Nancy.DefaultStaticContentProvider" /> class, using the
        /// provided <paramref name="rootPathProvider" /> and <paramref name="conventions" />.
        /// </summary>
        /// <param name="rootPathProvider">The current root path provider.</param>
        /// <param name="conventions">The static content conventions.</param>
        public ResourceStaticContentProvider(IRootPathProvider rootPathProvider, StaticContentsConventions conventions)
        {
            this.rootPathProvider = rootPathProvider;
            this.rootPath = this.rootPathProvider.GetRootPath();
            this.conventions = conventions;
        }

        /// <summary>Gets the static content response, if possible.</summary>
        /// <param name="context">Current context</param>
        /// <returns>Response if serving content, null otherwise</returns>
        public Response GetContent(NancyContext context)
        {
            var response = GetContentImpl(context);
            Console.WriteLine("{0} : staticContent: {1}", response!=null? "OK" : "NG", context.Request.Path);
            return response;
        }

        private Response GetContentImpl(NancyContext context)
        {
            foreach (Func<NancyContext, string, Response> convention in this.conventions)
            {
                Response response = convention(context, this.rootPath);
                if (response != null)
                    return response;
            }
            return (Response) null;
        }
    }
}