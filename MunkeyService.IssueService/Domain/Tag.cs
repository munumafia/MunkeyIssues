using MunkeyIssues.Core.Domain;

namespace MunkeyIssues.IssueService.Domain
{
    public class Tag : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
