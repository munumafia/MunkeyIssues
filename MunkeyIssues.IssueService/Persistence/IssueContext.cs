using System.Data.Entity;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence
{
    public class IssueContext : DbContext, IIssueContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public IssueContext() : base("IssueService") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}