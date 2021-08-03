using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repos
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetOneBy(Expression<Func<T, bool>> predicate);
        void InsertRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
    }
}
