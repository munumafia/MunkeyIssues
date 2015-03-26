using AutoMapper;
using MunkeyIssues.Core.Messaging.Issues.Category;
using MunkeyIssues.Core.Messaging.Issues.Status;

namespace MunkeyIssues.IssueService.AutoMapper
{
    public class AutoMapperBuilder
    {
        public static void Build()
        {
            Mapper.CreateMap<Domain.Category, Category>();
            Mapper.CreateMap<Category, Domain.Category>();

            Mapper.CreateMap<Domain.Status, Status>();
            Mapper.CreateMap<Status, Domain.Status>();
        }
    }
}
