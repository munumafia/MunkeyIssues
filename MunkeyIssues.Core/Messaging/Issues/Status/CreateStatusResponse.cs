using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Status
{
    public class CreateStatusResponse : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }

        public MessageResult Result { get; set; }

        public Status Status { get; set; }

    }
}
