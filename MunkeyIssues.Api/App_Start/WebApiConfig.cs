using System.Web.Http;
using System.Web.Http.Cors;
using Drum;
using MunkeyIssues.Api.ResponseEnrichers;
using MunkeyIssues.Api.StructureMap;

namespace MunkeyIssues.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API filters and handlers
            config.MessageHandlers.Add(new EnrichingHandler());

            // Web API routes
            config.MapHttpAttributeRoutesAndUseUriMaker();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
