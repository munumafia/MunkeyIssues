using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Category
{
    public class GetCategoryRequest : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The message id
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// The ID of the category to retrieve
        /// </summary>
        public Guid CategoryId { get; set; }
    }
}
