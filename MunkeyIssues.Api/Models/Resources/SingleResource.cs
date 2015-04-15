namespace MunkeyIssues.Api.Models.Resources
{
    /// <summary>
    /// Represents a resource that contains a single item
    /// </summary>
    /// <typeparam name="TItem">The type of the item being represented by the resource</typeparam>
    public class SingleResource<TItem> : BaseResource
    {
        /// <summary>
        /// The item represented by the resource
        /// </summary>
        public TItem Item { get; set; }
    }
}