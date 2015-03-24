using MassTransit;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Web.StructureMap.Registries
{
    public class MassTransitRegistry : Registry
    {
        public MassTransitRegistry()
        {
            ForSingletonOf<IServiceBus>().Use(MassTransit.ServiceBusBuilder.Build());
        }
    }
}
