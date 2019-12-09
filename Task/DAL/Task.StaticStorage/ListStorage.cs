using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public T Get(int id)
        {
            listMovements.Exists(it => it.Id == id);
        }

        public T Update(T item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<T> ICrudData<T>.Get()
        {
            return listMovements;
        }
    }
}