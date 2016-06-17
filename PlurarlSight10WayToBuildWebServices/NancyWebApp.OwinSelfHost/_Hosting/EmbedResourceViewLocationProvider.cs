namespace NancyWebApp.OwinSelfHost._Hosting
{
    //public class EmbedResourceViewLocationProvider : IViewLocationProvider
    //{
    //    private readonly ResourceViewLocationProvider _defaultViewLocationProvider;

    //    public EmbedResourceViewLocationProvider()
    //    {
    //        _defaultViewLocationProvider = new ResourceViewLocationProvider();

    //        //This should be the assembly your views are embedded in
    //        var assembly = GetType().Assembly;
    //        var rootNamespaces = ResourceViewLocationProvider.RootNamespaces;

    //        // TODO: replace NancyEmbeddedViews.MyViews with your resource prefix
    //        //rootNamespaces.Add(assembly, "NancyEmbeddedViews.MyViews");
    //        rootNamespaces.Add(assembly, "NancyWebApp.OwinSelfHost.Views");
    //        rootNamespaces.Add(assembly, "NancyWebApp.OwinSelfHost");
    //    }

    //    public IEnumerable<ViewLocationResult> GetLocatedViews(IEnumerable<string> supportedViewExtensions)
    //    {
    //        var locatedViews = _defaultViewLocationProvider.GetLocatedViews(supportedViewExtensions).ToList();
    //        Console.WriteLine("GetLocatedViews()");
    //        foreach (var view in locatedViews)
    //        {
    //            Console.WriteLine("---> {0}", view);
    //        }
    //        return locatedViews;
    //    }

    //    public IEnumerable<ViewLocationResult> GetLocatedViews(IEnumerable<string> supportedViewExtensions, string location, string viewName)
    //    {
    //        var locatedViews =  _defaultViewLocationProvider.GetLocatedViews(supportedViewExtensions, location, viewName).ToList();

    //        Console.WriteLine("GetLocatedViews({0}, {1})", location, viewName);
    //        foreach(var view in locatedViews)
    //        {
    //            Console.WriteLine("---> {0}", view);
    //        }
    //        return locatedViews;
    //    }
    //}
}