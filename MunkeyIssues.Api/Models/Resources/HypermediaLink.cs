namespace MunkeyIssues.Api.Models.Resources
{
    /// <summary>
    /// Represents a hypermedia link
    /// </summary>
    public class HypermediaLink
    {
        /// <summary>
        /// The URI/URL that the link models
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Whether or not the HREF is templated
        /// </summary>
        public bool Templated { get; set; }
    }
}