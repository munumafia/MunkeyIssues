using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MunkeyIssues.Core.Messaging;

namespace MunkeyIssues.Web.ResponseMappers
{
    public interface IResponseMapper
    {
        HttpResponseMessage ForCreate<TViewModel>(HttpRequestMessage request, TViewModel viewModel, MessageResult result);
        HttpResponseMessage ForGet<TViewModel>(HttpRequestMessage request, TViewModel viewModel, MessageResult result);
    }
}