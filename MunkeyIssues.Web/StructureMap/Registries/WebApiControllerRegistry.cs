using System.Web.Http.Controllers;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MunkeyIssues.Web.StructureMap.Registries
{
    public class WebApiControllerRegistry : Registry
    {
        public WebApiControllerRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf<IHttpController>();
                x.WithDefaultConventions();
            });
        }
    }
}