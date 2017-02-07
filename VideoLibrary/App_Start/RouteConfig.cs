using System.Web.Mvc;
using System.Web.Routing;

namespace VideoLibrary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "VideoSearch",
            //    url: "VideoSearch/{title}/{year}/{director}",
            //    defaults: new { controller = "Videos", action = "VideoList", title = UrlParameter.Optional, year = UrlParameter.Optional, director = UrlParameter.Optional}
            //    );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
