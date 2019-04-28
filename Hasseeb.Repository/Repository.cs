using Hasseeb.Application.Domain;
using Hasseeb.Application.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hasseeb.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseObject
    {
        private readonly MyContext _context;
        private DbSet<T> _entities;
        string errorMessage = string.Empty;

        public Repository(MyContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
        }

        public T Get(int ID)
        {

            return _entities.SingleOrDefault(s => s.ID == ID);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Where(predicate);
            return query;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}


