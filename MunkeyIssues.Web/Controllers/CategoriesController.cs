using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MunkeyIssues.Core.Messaging.Issues.Category;
using MunkeyIssues.Web.Models;
using MunkeyIssues.Web.Services.Categories;
using MessageResult = MunkeyIssues.Core.Messaging.MessageResult;

namespace MunkeyIssues.Web.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMappingEngine _Mapper;

        public CategoriesController(ICategoryService categoryService, IMappingEngine mapper)
        {
            _CategoryService = categoryService;
            _Mapper = mapper;
        }

        public List<CategoryViewModel> Get()
        {
            return new List<CategoryViewModel>();
        }

        public Task<HttpResponseMessage> Get(int id)
        {
            var request = new GetCategoryRequest {CategoryId = id};
            return _CategoryService.GetCategoryAsync(request).ContinueWith(resp =>
            {
                var message = resp.Result;
                HttpResponseMessage response = null;

                switch (message.Result)
                {
                    case MessageResult.Success:
                        var viewModel = _Mapper.Map<CategoryViewModel>(message.Category);
                        response = Request.CreateResponse(HttpStatusCode.OK, viewModel);
                        break;
                    case MessageResult.NotFound:
                        response = new HttpResponseMessage(HttpStatusCode.NotFound);
                        break;
                    default:
                        response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                        break;
                }

                return response;
            });
        }

        public Task<HttpResponseMessage> Post(CategoryViewModel model)
        {
            var request = new CreateCategoryRequest { Category = _Mapper.Map<Category>(model) };
            return _CategoryService.CreateCategoryAsync(request).ContinueWith(resp =>
            {
                HttpResponseMessage response = null;
                var message = resp.Result;
                
                switch (message.Result)
                {
                    case MessageResult.Success:
                        var viewModel = _Mapper.Map<CategoryViewModel>(message.Category);
                        response = Request.CreateResponse(HttpStatusCode.OK, viewModel);
                        break;
                    default:
                        // Todo: Handle any validation errors here
                        response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                        break;
                }

                return response;
            });
        }
    }
}