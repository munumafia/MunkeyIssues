using MunkeyIssues.UserService.MassTransit.Consumers;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.UserService.StructureMap.Registries
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {
            ForConcreteType<UserConsumers>();
        }
    }
}
