using System.Net.Http;
using MunkeyIssues.Core.Messaging;

namespace MunkeyIssues.Api.ResponseMappers
{
    public interface IResponseMapper
    {
        HttpResponseMessage ForCreate<TViewModel>(HttpRequestMessage request, TViewModel viewModel, MessageResult result);
        HttpResponseMessage ForGet<TViewModel>(HttpRequestMessage request, TViewModel viewModel, MessageResult result);
    }
}