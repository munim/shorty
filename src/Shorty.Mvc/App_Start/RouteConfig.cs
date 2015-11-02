using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Shorty.Mvc.Infrastructure;

namespace Shorty.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Short",
                url: "{shortUrl}",
                defaults: new { controller = "Shortner", action = "Redirect", shortUrl = UrlParameter.Optional },
                constraints: new { shortUrl = new ShortUrlConstraint() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
