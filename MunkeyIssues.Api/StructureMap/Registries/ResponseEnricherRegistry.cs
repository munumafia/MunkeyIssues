using MunkeyIssues.Api.ResponseEnrichers;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MunkeyIssues.Api.StructureMap.Registries
{
    public class ResponseEnricherRegistry : Registry
    {
        public ResponseEnricherRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.AddAllTypesOf<IResponseEnricher>();
            });
        }
    }
}