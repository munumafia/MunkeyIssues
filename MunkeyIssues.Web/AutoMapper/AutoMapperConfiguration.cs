using AutoMapper;
using MunkeyIssues.Core.Messaging.Issues.Category;
using MunkeyIssues.Web.Models;

namespace MunkeyIssues.Web.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();
        }
    }
}
