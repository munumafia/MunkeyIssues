using MassTransit;
using MunkeyIssues.UserService.MassTransit;
using MunkeyIssues.UserService.StructureMap;
using StructureMap;

namespace MunkeyIssues.UserService
{
    public class UserService
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
