using MassTransit;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MunkeyIssues.IssueService.StructureMap.Registries
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {
            // Register all the consumers with StructureMap
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf<IConsumer>();
                x.WithDefaultConventions();
            });
        }
    }
}