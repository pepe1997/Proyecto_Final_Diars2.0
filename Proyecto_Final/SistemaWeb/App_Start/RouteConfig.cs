using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",

                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                ///defaults: new { controller = "MantenedorCliente", action = "ListarCliente", id = UrlParameter.Optional }
                //defaults: new { controller = "MantenedorHabitacion", action = "ListarHabitacion", id = UrlParameter.Optional }
                ///defaults: new { controller = "MantenedorServicio", action = "ListarServicio", id = UrlParameter.Optional }
                //defaults: new { controller = "Login", action = "VerificarAcceso", id = UrlParameter.Optional }
            ) ;
        }
    }
}
