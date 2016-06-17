using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NanyWebApp
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello Nancy!";
            Get["/home"] = _ => View["home"];
        }
    }
}