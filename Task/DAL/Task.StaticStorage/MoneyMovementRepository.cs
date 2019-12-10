using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;

namespace Task.StaticStorage
{
    public class MoneyMovementRepository<T> : IRepository<T>
        where T : IMoneyMovement
    {
        private static readonly List<T> moneyMovementList = new List<T>();
        private static int id = 0;

        public MoneyMovementRepository()
        {

        }

        public virtual int Add(T item)
        {
            var it = moneyMovementList.FirstOrDefault(i => i.Id == item.Id);

            if(it == null)
            {
                item.Id = id++;
                moneyMovementList.Add(item);
            }

            return it == null ? item.Id : -1;
        }

        public virtual bool Delete(int id)
        {
            return moneyMovementList.Remove(moneyMovementList.Find(it => it.Id == id));
        }

        public virtual T Get(int id)
        {
            return moneyMovementList.FirstOrDefault(it => it.Id == id);
        }

        public virtual T Update(int id, T item)
        {
            var result = Get(id);

            if (result != null)
            {
                result = item;
            }

            return result;
        }

        public virtual IEnumerable<T> Get()
        {
            return moneyMovementList;
        }
    }
}