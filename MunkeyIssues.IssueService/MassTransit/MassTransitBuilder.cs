using MassTransit;
using StructureMap;

namespace MunkeyIssues.IssueService.MassTransit
{
    public class MassTransitBuilder
    {
        public static IServiceBus Build(IContainer container)
        {
            var massTransit = ServiceBusFactory.New(bus =>
            {
                bus.UseRabbitMq();
                bus.ReceiveFrom("rabbitmq://localhost/MunkeyIssues_Issues");
                bus.Subscribe(x => x.LoadFrom(container));
            });

            container.Inject(massTransit);

            return massTransit;
        }
    }
}
