using System.Net.Http;
using Drum;
using MunkeyIssues.Api.Controllers;
using MunkeyIssues.Api.Extensions;
using MunkeyIssues.Api.Models;
using MunkeyIssues.Api.Models.Resources;

namespace MunkeyIssues.Api.ResponseEnrichers.User
{
    public class CategoryResponseEnricher : BaseResponseEnricher<SingleResource<CategoryViewModel>>
    {
        public override void Enrich(SingleResource<CategoryViewModel> content, HttpResponseMessage response)
        {
            AddSelfLink(content, response);
        }

        private static void AddSelfLink(SingleResource<CategoryViewModel> content, HttpResponseMessage response)
        {
            var uriMaker = response.RequestMessage.TryGetUriMakerFor<CategoriesController>();
            var uri = uriMaker.UriFor(c => c.Get(content.Item.Id));
            content.HypermediaLinks.AddSelf(uri.AbsolutePath);
        }
    }
}