using System.Linq.Expressions;

namespace PizzeriaApi.Data.Interface
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T Add(T entity);
        void AddRange(List<T> entityList);
        void Edit(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entityList);
        Task SaveChangesAsync();
    }
}
