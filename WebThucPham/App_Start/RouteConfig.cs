using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebThucPham
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductDetails",
                url: "{controller}/{Category.Thumb}/chi-tiet-{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "WebThucPham.Controllers" }
            );

            routes.MapRoute(
                name: "BlogDetails",
                url: "{controller}/chi-tiet-tin-tuc-{id}",
                defaults: new { controller = "Blog", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "WebThucPham.Controllers" }
            );

            routes.MapRoute(
                name: "ShoppingCart",
                url: "gio-hang",
                defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebThucPham.Controllers" }
            );

            routes.MapRoute(
                name: "CheckOut",
                url: "thanh-toan",
                defaults: new { controller = "ShoppingCart", action = "CheckOut", id = UrlParameter.Optional },
                namespaces: new[] { "WebThucPham.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebThucPham.Controllers" }
            );
        }
    }
}
