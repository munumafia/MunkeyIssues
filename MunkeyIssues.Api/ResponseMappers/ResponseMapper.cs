﻿using System.Net;
using System.Net.Http;
using MunkeyIssues.Api.Models.Resources;
using MunkeyIssues.Core.Messaging;

namespace MunkeyIssues.Api.ResponseMappers
{
    public class ResponseMapper : IResponseMapper
    {
        public HttpResponseMessage ForCreate<TViewModel>(HttpRequestMessage request, TViewModel viewModel, MessageResult result)
        {
            HttpResponseMessage response = null;
            switch (result)
            {
                case MessageResult.Success:
                    response = request.CreateResponse(HttpStatusCode.OK, viewModel);
                    break;
                default:
                    // Todo: Handle any validation errors here
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    break;
            }

            return response;
        }

        public HttpResponseMessage ForGet<TViewModel>(HttpRequestMessage request, TViewModel viewModel, MessageResult result)
        {
            HttpResponseMessage response = null;
            switch (result)
            {
                case MessageResult.Success:
                    var resource = new SingleResource<TViewModel> {Item = viewModel};
                    response = request.CreateResponse(HttpStatusCode.OK, resource);
                    break;
                case MessageResult.NotFound:
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    break;
                default:
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    break;
            }

            return response;
        }
    }
}