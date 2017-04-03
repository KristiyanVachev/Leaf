using System;
using System.Linq;
using Leaf.Data.Contracts;

namespace Leaf.Data
{
    public class Repository<T> : IRepository<T>
      where T : class
    {
        private readonly ILeafDbContext dbContext;

        public Repository(ILeafDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext cannot be null");
            }

            this.dbContext = dbContext;
        }

        public IQueryable<T> Entities => this.dbContext.DbSet<T>();

        public void Add(T entity)
        {
            this.dbContext.SetAdded(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.SetDeleted(entity);
        }

        public T GetById(object id)
        {
            return this.dbContext.DbSet<T>().Find(id);
        }

        public void Update(T entity)
        {
            this.dbContext.SetUpdated(entity);
        }
    }
}
