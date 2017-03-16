using System.Data.Entity;

namespace Leaf.Data.Contracts
{
    public interface ILeafDbContext
    {
        IDbSet<TEntity> DbSet<TEntity>()
            where TEntity : class;

        int SaveChanges();
        
        void SetAdded<TEntry>(TEntry entity)
           where TEntry : class;

        void SetDeleted<TEntry>(TEntry entity)
            where TEntry : class;

        void SetUpdated<TEntry>(TEntry entity)
            where TEntry : class;
    }
}
