using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Status
{
    public class GetStatusRequest : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; private set; }

        public int StatusId { get; set; }

        public GetStatusRequest()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}
