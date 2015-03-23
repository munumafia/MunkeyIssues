using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence.Mappings
{
    public class TagMapping : EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasColumnName("TagId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name);
        }
    }
}
