using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;

namespace Task.StaticStorage
{
    public class UserRepository<T> : IRepository<T>
        where T : IUser
    {
        private static readonly List<T> userList;

        static UserRepository()
        {
            userList = new List<T>();
        }

        public bool Add(T item)
        {
            bool result = userList.Contains(item);

            if (result)
            {
                userList.Add(item);
            }

            return result;
        }

        public bool Delete(int id)
        {
            return userList.Remove(userList.Find(it => it.Id == id));
        }

        public T Get(int id)
        {
            return userList.FirstOrDefault(it => it.Id == id);
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
            return userList;
        }
    }
}