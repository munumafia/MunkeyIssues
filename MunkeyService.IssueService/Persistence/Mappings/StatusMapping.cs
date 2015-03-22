using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyService.IssueService.Domain;

namespace MunkeyService.IssueService.Persistence.Mappings
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
