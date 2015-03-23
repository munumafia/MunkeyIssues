using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence.Mappings
{
    public class IssueMapping : EntityTypeConfiguration<Issue>
    {
        public IssueMapping()
        {
            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("IssueId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Title);
            Property(i => i.Description);
            Property(i => i.AssignedToId);
            Property(i => i.CategoryId);
            Property(i => i.CreatedById);
            Property(i => i.CreatedOn);
            Property(i => i.LaneId);
            Property(i => i.PriorityId);
            Property(i => i.ProjectId);
            Property(i => i.StatusId);
        }
    }
}
