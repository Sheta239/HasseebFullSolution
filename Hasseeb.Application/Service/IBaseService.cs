using Hasseeb.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasseeb.Application.Service
{
    public interface IBaseService<T> where T : BaseObject
    {
        IEnumerable<T> GetAll();
        T GetID(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}

