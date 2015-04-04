using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Issues.Category;

namespace MunkeyIssues.Api.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IServiceBusService _ServiceBusService;

        public CategoryService(IServiceBusService serviceBusService)
        {
            _ServiceBusService = serviceBusService;
        }

        public Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request)
        {
            return _ServiceBusService.ExecuteRequestAsync<CreateCategoryRequest, CreateCategoryResponse>(request);
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            return _ServiceBusService.ExecuteRequest<CreateCategoryRequest, CreateCategoryResponse>(request);
        }

        public Task<GetCategoryResponse> GetCategoryAsync(GetCategoryRequest request)
        {
            return _ServiceBusService.ExecuteRequestAsync<GetCategoryRequest, GetCategoryResponse>(request);
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest request)
        {
            return _ServiceBusService.ExecuteRequest<GetCategoryRequest, GetCategoryResponse>(request);
        }
    }
}
