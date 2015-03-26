using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Status
{
    public class CreateStatusRequest : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; private set; }

        public MessageResult Result { get; set; }

        public Status Status { get; set; }

        public CreateStatusRequest()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}
