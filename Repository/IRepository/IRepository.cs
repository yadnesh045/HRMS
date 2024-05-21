using System.Linq.Expressions;

namespace HRMS.Repository.IRepository
{
    public interface IRepository<T> where T : class

    {
        T Get(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false);

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
