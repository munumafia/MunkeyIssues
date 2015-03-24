using MassTransit;
using MunkeyIssues.IssueService.MassTransit;
using MunkeyIssues.IssueService.StructureMap;
using StructureMap;

namespace MunkeyIssues.IssueService
{
    public class IssueService
    {
        private IContainer _Container;
        private IServiceBus _ServiceBus;

        public void Start()
        {
            _Container = ContainerBuilder.Build();
            _ServiceBus = MassTransitBuilder.Build(_Container);
        }

        public void Stop()
        {
            _ServiceBus.Dispose();
        }
    }
}