using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Magnum.Extensions;
using MassTransit;
using MunkeyIssues.Core.Messaging.Issues.Category;
using MunkeyIssues.Web.Models;
using MessageResult = MunkeyIssues.Core.Messaging.MessageResult;

namespace MunkeyIssues.Web.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly IServiceBus _ServiceBus;
        private readonly IMappingEngine _Mapper;

        public CategoriesController(IServiceBus serviceBus, IMappingEngine mapper)
        {
            _ServiceBus = serviceBus;
            _Mapper = mapper;
        }

        public List<CategoryViewModel> Get()
        {
            return new List<CategoryViewModel>();
        }

        public CategoryViewModel Get(int id)
        {
            CategoryViewModel category = null;

            _ServiceBus.PublishRequest(new GetCategoryRequest() {CategoryId = id}, x =>
            {
                x.Handle<GetCategoryResponse>(response =>
                {
                    if (response.Result == MessageResult.Error)
                    {
                        // Something went wrong here, need to just handle it
                    }

                    if (response.Result == MessageResult.NotFound)
                    {
                        // Need to return a 404 message
                    }

                    category = _Mapper.Map<Category, CategoryViewModel>(response.Category);
                });

                x.SetTimeout(30.Seconds());
            });

            return category;
        }
    }
}