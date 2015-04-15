using System.Net.Http;

namespace MunkeyIssues.Api.ResponseEnrichers
{
    /// <summary>
    /// Interface for enriching a HttpResponseMessage with additional information
    /// See http://benfoster.io/blog/generating-hypermedia-links-in-aspnet-web-api
    /// </summary>
    public interface IResponseEnricher
    {
        /// <summary>
        /// Whether or not the enricher can enrich the specified HttpResponseMessage
        /// </summary>
        /// <param name="response">The HttpResponseMessage to enrich</param>
        /// <returns>True if the enricher can handle the message, otherwise false</returns>
        bool CanEnrich(HttpResponseMessage response);

        /// <summary>
        /// Enriches the specified HttpResponseMessage with additional information
        /// </summary>
        /// <param name="response">The HttpResponseMessage to enrich</param>
        /// <returns>The enriched HttpResponseMessage</returns>
        HttpResponseMessage Enrich(HttpResponseMessage response);
    }
}
