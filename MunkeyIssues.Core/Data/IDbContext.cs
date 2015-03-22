using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace MunkeyIssues.Core.Data
{
    public interface IDbContext
    {
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class; 
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
