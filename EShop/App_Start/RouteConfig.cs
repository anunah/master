using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "UserResTest",
                url: "{controller}/{action}/{username}",
                defaults: new { controller = "Home", action = "Index", },
                constraints: new { action = "UserResultTest" }
            );
            routes.MapRoute(
                name: "EndTest",
                url: "{controller}/{action}/{idUserTest}",
                defaults: new { controller = "Home", action = "Index", },
                constraints: new { action = "EndTest" }
            );
            routes.MapRoute(
                name: "ResTest",
                url: "{controller}/{action}/{idUserTest}",
                defaults: new { controller = "Home", action = "Index", },
                constraints: new { action = "ResTest" }
            );
            routes.MapRoute(
                name: "TestQ",
                url: "{controller}/{action}/{idTest}/{idQ}",
                defaults: new { controller = "Home", action = "Index", idTest = UrlParameter.Optional, idQ = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "StartTest",
                url: "{controller}/{action}/{idTest}",
                defaults: new { controller = "Home", action = "Index", idTest = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}