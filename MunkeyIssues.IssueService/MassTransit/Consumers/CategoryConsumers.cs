using AutoMapper;
using MassTransit;
using MunkeyIssues.Core.Messaging;
using MunkeyIssues.Core.Messaging.Issues.Category;
using MunkeyIssues.IssueService.Persistence;

namespace MunkeyIssues.IssueService.MassTransit.Consumers
{
    public class CategoryConsumers : Consumes<GetCategoryRequest>.Context, Consumes<CreateCategoryRequest>.Context
    {
        private readonly IIssueContext _DbContext;
        private readonly IMappingEngine _Mapper;

        public CategoryConsumers(IIssueContext dbContext, IMappingEngine mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public void Consume(IConsumeContext<GetCategoryRequest> context)
        {
            var request = context.Message;
            var category = _DbContext.Categories.Find(request.CategoryId);

            var response = new GetCategoryResponse
            {
                Category = _Mapper.Map<Category>(category),
                CorrelationId = request.CorrelationId,
                Result = category != null ? MessageResult.Success : MessageResult.NotFound
            };

            context.Respond(response);
        }

        public void Consume(IConsumeContext<CreateCategoryRequest> context)
        {
            var request = context.Message;
            var category = _Mapper.Map<Domain.Category>(request.Category);

            _DbContext.Categories.Add(category);
            _DbContext.SaveChanges();

            var response = new CreateCategoryResponse
            {
                Category = _Mapper.Map<Category>(category),
                CorrelationId = request.CorrelationId,
                Result = MessageResult.Success
            };

            context.Respond(response);
        }
    }
}
