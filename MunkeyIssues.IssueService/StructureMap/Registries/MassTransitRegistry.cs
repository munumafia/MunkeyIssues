using MassTransit;
using MunkeyIssues.IssueService.MassTransit.Consumers;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MunkeyIssues.IssueService.StructureMap.Registries
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {
            ForConcreteType<CategoryConsumers>();
            ForConcreteType<StatusConsumers>();
        }
    }
}