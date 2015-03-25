using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MunkeyIssues.Core.Messaging.Issues.Category;

namespace MunkeyIssues.IssueService.AutoMapper
{
    public class AutoMapperBuilder
    {
        public static void Build()
        {
            Mapper.CreateMap<Domain.Category, Category>();
            Mapper.CreateMap<Category, Domain.Category>();
        }
    }
}
