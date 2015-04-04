using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MunkeyIssues.Api.Models;
using MunkeyIssues.Api.ResponseMappers;
using MunkeyIssues.Api.Services.Categories;
using MunkeyIssues.Core.Messaging.Issues.Category;

namespace MunkeyIssues.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMappingEngine _Mapper;
        private readonly IResponseMapper _ResponseMapper;

        public CategoriesController(ICategoryService categoryService, IMappingEngine mapper, IResponseMapper responseMapper)
        {
            _CategoryService = categoryService;
            _Mapper = mapper;
            _ResponseMapper = responseMapper;
        }

        public Task<HttpResponseMessage> Get(int id)
        {
            var request = new GetCategoryRequest {CategoryId = id};
            return _CategoryService.GetCategoryAsync(request).ContinueWith(resp =>
            {
                var message = resp.Result;
                var viewModel = _Mapper.Map<CategoryViewModel>(message.Category);
                return _ResponseMapper.ForGet(Request, viewModel, message.Result);
            });
        }

        public Task<HttpResponseMessage> Post(CategoryViewModel model)
        {
            var request = new CreateCategoryRequest { Category = _Mapper.Map<Category>(model) };
            return _CategoryService.CreateCategoryAsync(request).ContinueWith(resp =>
            {
                var message = resp.Result;
                var viewModel = _Mapper.Map<CategoryViewModel>(message.Category);
                return _ResponseMapper.ForCreate(Request, viewModel, message.Result);
            });
        }
    }
}