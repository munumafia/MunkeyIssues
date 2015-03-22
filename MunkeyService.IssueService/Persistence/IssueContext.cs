using System.Data.Entity;
using MunkeyIssues.Core.Data;
using MunkeyService.IssueService.Domain;

namespace MunkeyService.IssueService.Persistence
{
    public class IssueContext : DbContext, IDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}