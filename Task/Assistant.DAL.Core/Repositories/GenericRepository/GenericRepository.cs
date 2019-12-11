using Assistant.DAL.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assistant.DAL.Core.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AssistantContext context;
        private readonly List<TEntity> list;

        public GenericRepository(AssistantContext context)
        {
            this.context = context;
            list = this.context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            if (item != null)
            {
                list.Add(item);
            }

            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            return list.FirstOrDefault(item => (int)(item.GetType()
                                                          .GetProperties()
                                                          .FirstOrDefault(p => p.Name
                                                                                .ToLower()
                                                                                .Contains("id"))?
                                                          .GetValue(this)) == id);
        }

        public IEnumerable<TEntity> Get()
        {
            return list;
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return list.Where(predicate);
        }

        public void Remove(TEntity item)
        {
            list.Remove(item);
        }

        public void Update(TEntity item)
        {
            var changedItem = GetById((int)item.GetType().GetProperties().FirstOrDefault(p => p.Name.ToLower().Contains("id"))?.GetValue(this));

            //replacing values
            //adding value

            throw new NotImplementedException();
        }
    }
}
