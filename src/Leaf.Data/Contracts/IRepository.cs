using System.Linq;

namespace Leaf.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);

        IQueryable<T> Entities { get; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
