using MassTransit;
using MunkeyIssues.IssueService.StructureMap.Registries;
using StructureMap;
using Topshelf;

namespace MunkeyIssues.IssueService
{
    class Program
    {
        static void Main()
        {
            var container = new Container(x =>
            {
                x.AddRegistry(new MassTransitRegistry());
                x.AddRegistry(new PersistenceRegistry());
            });

            var massTransit = ServiceBusFactory.New(bus =>
            {
                bus.UseRabbitMq();
                bus.ReceiveFrom("rabbitmq://localhost/MunkeyIssues_Issues");
                bus.Subscribe(x => x.LoadFrom(container));
            });

            container.Inject(massTransit);

            HostFactory.Run(x =>
            {
                x.Service<IssueService>(s =>
                {
                    s.ConstructUsing(obj => new IssueService());
                    s.WhenStarted(obj => obj.Start());
                    s.WhenStopped(obj => obj.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Issues microservice for MunkeyIssues");
                x.SetDisplayName("MunkeyIssues Issues microservice");
                x.SetServiceName("MunkeyIssuesIssuesService");
            });
        }
    }
}
