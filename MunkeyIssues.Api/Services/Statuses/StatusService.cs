using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Issues.Status;

namespace MunkeyIssues.Api.Services.Statuses
{
    public class StatusService : IStatusService
    {
        private readonly IServiceBusService _ServiceBusService;

        public StatusService(IServiceBusService serviceBusService)
        {
            _ServiceBusService = serviceBusService;
        }

        public Task<CreateStatusResponse> CreateStatusAsync(CreateStatusRequest request)
        {
            return _ServiceBusService
                .ExecuteRequestAsync<CreateStatusRequest, CreateStatusResponse>(request);
        }

        public CreateStatusResponse CreateStatus(CreateStatusRequest request)
        {
            return _ServiceBusService
                .ExecuteRequest<CreateStatusRequest, CreateStatusResponse>(request);
        }

        public Task<GetStatusResponse> GetStatusAsync(GetStatusRequest request)
        {
            return _ServiceBusService
                .ExecuteRequestAsync<GetStatusRequest, GetStatusResponse>(request);
        }

        public GetStatusResponse GetStatus(GetStatusRequest request)
        {
            return _ServiceBusService
                .ExecuteRequest<GetStatusRequest, GetStatusResponse>(request);
        }
    }
}