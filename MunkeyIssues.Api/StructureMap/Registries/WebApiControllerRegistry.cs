using MunkeyIssues.Api.StructureMap.Conventions;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MunkeyIssues.Api.StructureMap.Registries
{
    public class WebApiControllerRegistry : Registry
    {
        public WebApiControllerRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.Convention<WebApiControllerConvention>();    
            });
        }
    }
}