using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MebelTemplate
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("AccountUser", "AccountUser/{action}/{id}", new { controller = "AccountUser", action = "Index", id = UrlParameter.Optional }, new[] { "MebelTemplate.Controllers" });

            routes.MapRoute(
                name: null,
                url: "admin/{controller}/{action}/{id}",
                defaults: new { area = "admin", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MebelTemplate.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MebelTemplate.Controllers" }

                );
        }
    }
}
