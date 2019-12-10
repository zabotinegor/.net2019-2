using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;
using Task.StaticStorage;

namespace Task.ProcessingLogic
{
    public class UserRepositoryAggregator<T> : IRepository<T>
        where T : IUser
    {
        private IRepository<T> userRepository;

        public UserRepositoryAggregator()
        {
            userRepository = new UserRepository<T>();
        }

        public int Add(T item)
        {
            if (string.IsNullOrEmpty(item.FirstName) || string.IsNullOrEmpty(item.LastName))
            {
                return -1;
            }

            var tempItem = userRepository.Get().FirstOrDefault(it => string.Equals(it.FirstName, item.FirstName) &&
                    string.Equals(it.LastName, item.LastName));

            if (tempItem == null)
            {
                userRepository.Add(item);
                return item.Id;
            }
            else
            {
                return tempItem.Id;
            }
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new System.NotImplementedException();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(int id, T item)
        {
            throw new System.NotImplementedException();
        }
    }
}