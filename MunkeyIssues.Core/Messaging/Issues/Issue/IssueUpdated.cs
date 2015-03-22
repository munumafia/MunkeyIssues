using System;

namespace MunkeyIssues.Core.Messaging.Issues.Issue
{
    public class IssueUpdated
    {
        /// <summary>
        /// The ID of the issue that was updated
        /// </summary>
        public Guid IssueId { get; set; }

        /// <summary>
        /// The date and time when the issue was updated
        /// </summary>
        public string UpdatedOn { get; set; }
    }
}
