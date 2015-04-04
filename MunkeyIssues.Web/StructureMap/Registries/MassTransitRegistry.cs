using MassTransit;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Api.StructureMap.Registries
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {
            ForSingletonOf<IServiceBus>().Use(MassTransit.ServiceBusBuilder.Build());
        }
    }
}
