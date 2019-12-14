using System;
using System.Collections.Generic;
using System.Linq;

namespace Assistant.DAL.Core.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        TEntity FindById(object id);

        IQueryable<TEntity> Get();

        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        public void Remove(object id);

        void Remove(TEntity entity);

        void Update(TEntity entity);
    }
}
