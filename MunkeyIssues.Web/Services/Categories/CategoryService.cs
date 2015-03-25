using System;
using System.Threading.Tasks;
using MassTransit;
using MunkeyIssues.Core.Messaging.Issues.Category;

namespace MunkeyIssues.Web.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly TimeSpan _Timeout;
        private readonly IServiceBus _ServiceBus;

        public CategoryService(TimeSpan timeout, IServiceBus serviceBus)
        {
            _Timeout = timeout;
            _ServiceBus = serviceBus;
        }

        public Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request)
        {
            return ExecuteRequestAsync<CreateCategoryRequest, CreateCategoryResponse>(request);
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            return ExecuteRequest<CreateCategoryRequest, CreateCategoryResponse>(request);
        }

        public Task<GetCategoryResponse> GetCategoryAsync(GetCategoryRequest request)
        {
            return ExecuteRequestAsync<GetCategoryRequest, GetCategoryResponse>(request);
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest request)
        {
            return ExecuteRequest<GetCategoryRequest, GetCategoryResponse>(request);
        }

        private Task<TResponse> ExecuteRequestAsync<TRequest, TResponse>(TRequest request) 
            where TRequest : class 
            where TResponse : class
        {
            return Task.Factory.StartNew(() => ExecuteRequest<TRequest, TResponse>(request));
        }

        private TResponse ExecuteRequest<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            TResponse response = null;

            _ServiceBus.PublishRequest(request, x =>
            {
                x.Handle<TResponse>(resp => response = resp);
                x.SetTimeout(_Timeout);
            });

            return response;
        }
    }
}
