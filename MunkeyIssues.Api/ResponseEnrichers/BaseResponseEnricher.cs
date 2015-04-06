using System;
using System.Net.Http;

namespace MunkeyIssues.Api.ResponseEnrichers
{
    /// <summary>
    /// Class used as a base class for custom HttpResponseMessage enrichers
    /// </summary>
    /// <typeparam name="TResource">The type of resource to enrich</typeparam>
    public abstract class BaseResponseEnricher<TResource> : IResponseEnricher
    {
        /// <summary>
        /// Tests whether the enricher can enrich the specified type
        /// </summary>
        /// <param name="contentType">The type to test whether or not can be enriched by this enricher</param>
        /// <returns>True if the type can be enriched by this enricher, false otherwise</returns>
        public bool CanEnrich(Type contentType)
        {
            return contentType == typeof (TResource);
        }

        /// <summary>
        /// Tests whether or not the enricher can enrich the specified response
        /// </summary>
        /// <param name="response">The response to test</param>
        /// <returns>True if the response can be enriched, false otherwise</returns>
        public bool CanEnrich(HttpResponseMessage response)
        {
            var content = response.Content as ObjectContent;
            return (content != null && CanEnrich(content.ObjectType));
        }

        /// <summary>
        /// Enriches the specified resource
        /// </summary>
        /// <param name="content">The content to enrich</param>
        /// <param name="response"></param>
        public abstract void Enrich(TResource content, HttpResponseMessage response);

        /// <summary>
        /// Enriches the specified HttpResponseMessage
        /// </summary>
        /// <param name="response">The HttpResponseMessage to enrich</param>
        /// <returns>The enriched HttpResponseMessage</returns>
        public HttpResponseMessage Enrich(HttpResponseMessage response)
        {
            TResource content;
            if (response.TryGetContentValue(out content))
            {
                Enrich(content, response);
            }

            return response;
        }
    }
}