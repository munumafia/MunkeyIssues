using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyIssues.UserService.Domain;

namespace MunkeyIssues.UserService.Persistence.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .HasColumnName("UserID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.EmailAddress);
            Property(u => u.FirstName);
            Property(u => u.IsDisabled);
            Property(u => u.LastName);
            Property(u => u.Password);
            Property(u => u.Salt);
        }
    }
}
