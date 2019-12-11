using System.Collections.Generic;
using System.Reflection;

namespace Assistant.DAL.Core.Models
{
    public class AssistantContext
    {
        public AssistantContext()
        {
            Users = new List<User>();
            MoneyMovements = new List<MoneyMovement>();
        }

        public List<User> Users { get; set; }

        public List<MoneyMovement> MoneyMovements { get; set; }

        public virtual List<TEntity> Set<TEntity>() where TEntity : class
        {
            IList<PropertyInfo> props = new List<PropertyInfo>(this.GetType().GetProperties());

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(this);
                
                if (propValue is List<TEntity> list)
                {
                    return list;
                }
            }

            return null;
        }
    }
}
