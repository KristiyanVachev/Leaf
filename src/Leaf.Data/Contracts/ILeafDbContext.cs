using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Leaf.Data.Contracts
{
    public interface ILeafDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
