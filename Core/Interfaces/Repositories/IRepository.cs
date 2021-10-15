using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>predicate);

        void Update(TEntity entity);

        void Remove(int id);
    }
}