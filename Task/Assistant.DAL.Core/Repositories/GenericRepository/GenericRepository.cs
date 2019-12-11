using Assistant.DAL.Core.Models;
using System;
using System.Collections.Generic;

namespace Assistant.DAL.Core.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AssistantContext context;
        private readonly List<TEntity> list;

        public GenericRepository(AssistantContext context)
        {
            this.context = context;

            //dbSet = this.context.Set<TEntity>();
            //ist = this.context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
