using System;
using System.Threading.Tasks;
using MassTransit;

namespace MunkeyIssues.Api.Services
{
    public class ServiceBusService : IServiceBusService
    {
        private readonly IServiceBus _ServiceBus;
        private readonly TimeSpan _Timeout;

        public ServiceBusService(IServiceBus serviceBus, TimeSpan timeout)
        {
            _ServiceBus = serviceBus;
            _Timeout = timeout;
        }

        public Task<TResponse> ExecuteRequestAsync<TRequest, TResponse>(TRequest request) 
            where TRequest : class 
            where TResponse : class
        {
            return Task.Factory.StartNew(() => ExecuteRequest<TRequest, TResponse>(request));
        }

        public TResponse ExecuteRequest<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            TResponse response = null;

            _ServiceBus.PublishRequest(request, x =>
            {
                x.Handle<TResponse>(resp => response = resp);
                x.SetTimeout(_Timeout);
            });

            return response;
        }
    }
}