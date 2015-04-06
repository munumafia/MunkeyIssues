using System.Collections.Generic;
using Newtonsoft.Json;

namespace MunkeyIssues.Api.Models.Resources
{
    /// <summary>
    /// Contains shared members for all classes in the class heirarchy
    /// </summary>
    public abstract class BaseResource
    {
        /// <summary>
        /// Dictionary of hypermedia links associated with this resource
        /// </summary>
        [JsonProperty(PropertyName = "links")]
        public IDictionary<string, HypermediaLink> HypermediaLinks { get; set; }

        /// <summary>
        /// Constructor for the BaseResource
        /// </summary>
        protected BaseResource()
        {
            HypermediaLinks = new Dictionary<string, HypermediaLink>();
        }
    }
}