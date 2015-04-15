using System.Collections.Generic;

namespace MunkeyIssues.Api.Models.Resources
{
    /// <summary>
    /// Represents a resource that contains a list of items that 
    /// can be paged through
    /// </summary>
    /// <typeparam name="TItem">The type of item that is being represented by the resource</typeparam>
    public class PagedResource<TItem> : BaseResource
    {
        /// <summary>
        /// List of items represented by the resource
        /// </summary>
        public IList<TItem> Items { get; set; }

        /// <summary>
        /// The total number of items included in this resource
        /// </summary>
        public int TotalItems
        {
            get { return Items.Count; }
        }

        /// <summary>
        /// Constructs a new PagedResource
        /// </summary>
        public PagedResource()
        {
            Items = new List<TItem>();
        }
    }
}