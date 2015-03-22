using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Category
{
    public class CreateCategoryRequest : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The message id
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// The category to create
        /// </summary>
        public Category Category { get; set; }
    }
}
