using System;
using System.Collections.Generic;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Issues.Category
{
    public class CreateCategoryResponse : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The message id
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Any errors that occurred when creating the category
        /// </summary>
        public IList<string> Errors { get; set; }

        /// <summary>
        /// The result of the original message
        /// </summary>
        public MessageResult Result { get; set; }
    }
}
