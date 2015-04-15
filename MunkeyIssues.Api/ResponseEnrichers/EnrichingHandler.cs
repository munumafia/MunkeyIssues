using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MunkeyIssues.Api.ResponseEnrichers
{
    public class EnrichingHandler : DelegatingHandler 
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                var enrichers = response.RequestMessage.GetDependencyScope().GetServices(typeof (IResponseEnricher));

                return enrichers.Cast<IResponseEnricher>()
                    .Where(e => e.CanEnrich(response))
                    .Aggregate(response, (resp, enricher) => enricher.Enrich(response));
            });
        }
    }
}