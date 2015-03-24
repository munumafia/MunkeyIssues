using MunkeyIssues.IssueService.MassTransit.Consumers;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.IssueService.StructureMap.Registries
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {
            ForConcreteType<CategoryConsumers>();
        }
    }
}