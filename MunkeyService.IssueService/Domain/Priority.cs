using MunkeyIssues.Core.Domain;

namespace MunkeyService.IssueService.Domain
{
    public class Priority : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DefaultDisplayOrder { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDefault { get; set; }
    }
}
