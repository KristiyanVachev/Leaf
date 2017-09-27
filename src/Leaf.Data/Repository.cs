using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Bytes2you.Validation;
using Leaf.Data.Contracts;

namespace Leaf.Data
{
    public class Repository<T> : IRepository<T>
      where T : class
    {
        private readonly ILeafDbContext dbContext;

        public Repository(ILeafDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext cannot be null").IsNull().Throw();

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

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return this.dbContext.DbSet<T>()
                .Include(children)
                .Where(filter);
        }

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string otherChildren)
        {
            return this.dbContext.DbSet<T>()
                .Include(children)
                .Include(otherChildren)
                .Where(filter);
        }

        public void Update(T entity)
        {
            this.dbContext.SetUpdated(entity);
        }
    }
}
