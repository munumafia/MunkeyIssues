using System;
using System.Collections.Generic;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Category
{
    public class GetCategoryResponse : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The category that was retrieved
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// The ID of the message
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Any errors associated with the message
        /// </summary>
        public IList<string> Errors { get; set; }

        /// <summary>
        /// The result of the message
        /// </summary>
        public MessageResult Result { get; set; }
    }
}
