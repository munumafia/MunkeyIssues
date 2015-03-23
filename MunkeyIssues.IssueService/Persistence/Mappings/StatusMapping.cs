using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence.Mappings
{
    public class StatusMapping : EntityTypeConfiguration<Status>
    {
        public StatusMapping()
        {
            HasKey(s => s.Id);

            Property(s => s.Id)
                .HasColumnName("CategoryId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.IsDefault);
            Property(s => s.IsDeleted);
            Property(s => s.Name);
        }
    }
}
