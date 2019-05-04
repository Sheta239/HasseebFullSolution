﻿using Hasseeb.Application.Domain;
using Hasseeb.Application.Repository;
using Hasseeb.Application.Service;
using JqueryDataTables.ServerSide.AspNetCoreWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hasseeb.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseObject
    {
        public IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;

        }

        public void Delete(int id)
        {
            _repository.Delete(_repository.Get(id));
            _repository.SaveChanges();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetBy(predicate);
        }

        public async Task<IEnumerable<T>> GetAll(DTParameters param)
        {
            return await _repository.GetAll(param);
        }

        public T GetID(int id)
        {
            return _repository.Get(id);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
            _repository.SaveChanges();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.SaveChanges();
        }
    }
}
