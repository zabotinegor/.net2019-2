using Assistant.DAL.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Assistant.DAL.Core.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AssistantContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(AssistantContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public TEntity FindById(object id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> Get()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.Where(predicate).AsQueryable();
        }

        public void Remove(object id)
        {
            TEntity entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
