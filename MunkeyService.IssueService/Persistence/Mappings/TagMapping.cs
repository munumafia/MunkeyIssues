using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyService.IssueService.Domain;

namespace MunkeyService.IssueService.Persistence.Mappings
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
