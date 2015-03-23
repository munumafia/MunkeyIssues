using System.Data.Entity;
using MunkeyIssues.Core.Data;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence
{
    public interface IIssueContext : IDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Issue> Issues { get; set; }
        DbSet<Priority> Priorities { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Tag> Tags { get; set; }
    }
}