using System.Data.Entity;
using MunkeyIssues.Core.Data;
using MunkeyIssues.UserService.Domain;

namespace MunkeyIssues.UserService.Persistence
{
    public interface IUserContext : IDbContext
    {
        DbSet<User> Users { get; set; }
    }
}