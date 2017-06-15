using System.Web.Mvc;
using System.Web.Routing;

namespace Monitor.WebManage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Monitor.WebManage.Controllers" }
            );
        }
    }
}