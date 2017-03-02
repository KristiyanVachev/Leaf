using System;
using Leaf.Data.Contracts;

namespace Leaf.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILeafDbContext dbContext;

        public UnitOfWork(ILeafDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext cannot be null");
            }

            this.dbContext = dbContext;
        }

        public void Dispose()
        {

        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
