using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzeriaApi.Data.Interface;
using System.Linq.Expressions;

namespace PizzeriaApi.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PizzeriaDbContext _context { get; set; }
        public RepositoryBase(PizzeriaDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
           var result= _context.Set<T>().Add(entity).Entity;
            return result;
        }
        public void AddRange(List<T> entityList)
        {
            _context.Set<T>().AddRange(entityList);
        }
        public void Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
        }
        public void DeleteRange(List<T> entityList)
        {
            _context.Set<T>().RemoveRange(entityList);
        }
        public void Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
