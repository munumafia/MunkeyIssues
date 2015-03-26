using AutoMapper;
using MassTransit;
using MunkeyIssues.Core.Messaging;
using MunkeyIssues.Core.Messaging.Issues.Status;
using MunkeyIssues.IssueService.Persistence;

namespace MunkeyIssues.IssueService.MassTransit.Consumers
{
    public class StatusConsumers : Consumes<CreateStatusRequest>.Context, Consumes<GetStatusRequest>.Context
    {
        private readonly IIssueContext _DbContext;
        private readonly IMappingEngine _Mapper;

        public StatusConsumers(IIssueContext dbContext, IMappingEngine mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public void Consume(IConsumeContext<CreateStatusRequest> context)
        {
            var message = context.Message;
            var status = _Mapper.Map<Domain.Status>(message.Status);

            _DbContext.Statuses.Add(status);
            _DbContext.SaveChanges();

            context.Respond(new CreateStatusResponse
            {
                CorrelationId = message.CorrelationId,
                Result = MessageResult.Success,
                Status = _Mapper.Map<Status>(status)
            });
        }

        public void Consume(IConsumeContext<GetStatusRequest> context)
        {
            var message = context.Message;
            var status = _DbContext.Statuses.Find(message.StatusId);

            context.Respond(new GetStatusResponse
            {
               CorrelationId = message.CorrelationId,
               Result = status != null ? MessageResult.Success : MessageResult.NotFound,
               Status = _Mapper.Map<Status>(status)
            });
        }
    }
}
