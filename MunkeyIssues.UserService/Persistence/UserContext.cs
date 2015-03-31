using System.Data.Entity;
using MunkeyIssues.UserService.Domain;

namespace MunkeyIssues.UserService.Persistence
{
    public class UserContext : DbContext, IUserContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base("UserService")
        {
        
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}