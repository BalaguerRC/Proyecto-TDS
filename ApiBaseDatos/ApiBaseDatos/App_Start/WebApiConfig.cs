using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiBaseDatos
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            xml.UseXmlSerializer = true;
            // Configuración y servicios de Web API
            var cors = new EnableCorsAttribute("*", "Origin, Content-Type, OPTIONS", "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(cors);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
