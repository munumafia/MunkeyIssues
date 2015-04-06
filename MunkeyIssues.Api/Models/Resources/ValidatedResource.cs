using System.Collections.Generic;

namespace MunkeyIssues.Api.Models.Resources
{
    /// <summary>
    /// Represents a resource that has been validated on the server
    /// and may contain validation errors that need to be addressed
    /// by the client
    /// </summary>
    public class ValidatedResource<TItem> : SingleResource<TItem>
    {
        /// <summary>
        /// List of validation errors that were encountered
        /// </summary>
        public IList<string> ValidationErrors { get; set; }

        /// <summary>
        /// Constructs a new ValidatedResource
        /// </summary>
        public ValidatedResource()
        {
            ValidationErrors = new List<string>();
        }
    }
}