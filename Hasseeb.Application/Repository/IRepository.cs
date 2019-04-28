using Hasseeb.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasseeb.Application.Repository
{
    public interface IRepository<T> where T:BaseObject
    {
        IEnumerable<T> GetAll();
        T Get(int ID);
        IQueryable<T> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        void SaveChanges();
    }
}
