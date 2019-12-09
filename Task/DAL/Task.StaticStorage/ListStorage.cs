using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;

namespace Task.StaticStorage
{
    class ListStorage<T> : ICrudData<T>
        where T : IMoneyMovement
    {
        private static readonly List<T> listMovements;

        static ListStorage()
        {
            listMovements = new List<T>();
        }

        public bool Add(T item)
        {
            bool result = listMovements.Contains(item);

            if (result)
            {
                listMovements.Add(item);
            }

            return result;
        }

        public bool Delete(int id)
        {
            return listMovements.Remove(listMovements.Find(it => it.Id == id));
        }

        public T Get(int id)
        {
            return listMovements.FirstOrDefault(it => it.Id == id);
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

        IEnumerable<T> ICrudData<T>.Get()
        {
            return listMovements;
        }
    }
}