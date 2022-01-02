using System.Web.Http;

namespace alavi
{
    public static class WebApiConfig
    {


        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

         
          

        }  
        
    }
}