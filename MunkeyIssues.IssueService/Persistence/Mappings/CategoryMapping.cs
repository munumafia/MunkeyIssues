using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasColumnName("CategoryId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.IsDefault);
            Property(c => c.IsDeleted);
            Property(c => c.Name);
        }
    }
}
