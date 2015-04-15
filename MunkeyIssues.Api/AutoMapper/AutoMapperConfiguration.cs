using AutoMapper;
using MunkeyIssues.Api.Models;
using MunkeyIssues.Core.Messaging.Issues.Category;
using MunkeyIssues.Core.Messaging.Issues.Status;
using MunkeyIssues.Core.Messaging.Users.Register;

namespace MunkeyIssues.Api.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();

            Mapper.CreateMap<Status, StatusViewModel>();
            Mapper.CreateMap<StatusViewModel, Status>();

            Mapper.CreateMap<RegisterViewModel, RegisterUserRequest>();
        }
    }
}
