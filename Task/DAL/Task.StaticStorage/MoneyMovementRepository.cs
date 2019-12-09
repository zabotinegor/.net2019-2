using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;

namespace Task.StaticStorage
{
    public class MoneyMovementRepository<T> : IRepository<T>
        where T : IMoneyMovement
    {
        private static readonly List<T> moneyMovementList;

        static MoneyMovementRepository()
        {
            moneyMovementList = new List<T>();
        }

        public bool Add(T item)
        {
            bool result = moneyMovementList.Contains(item);

            if (result)
            {
                moneyMovementList.Add(item);
            }

            return result;
        }

        public bool Delete(int id)
        {
            return moneyMovementList.Remove(moneyMovementList.Find(it => it.Id == id));
        }

        public T Get(int id)
        {
            return moneyMovementList.FirstOrDefault(it => it.Id == id);
        }

        public bool Update(T item)
        {
            var result = Delete(item.Id);

            if (result)
            {
                Add(item);
            }

            return result;
        }

        IEnumerable<T> IRepository<T>.Get()
        {
            return moneyMovementList;
        }
    }
}