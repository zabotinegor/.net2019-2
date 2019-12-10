using System.Linq;
using Task.CommonTypes.Interfaces;
using Task.StaticStorage;

namespace Task.ProcessingLogic
{
    public class UserRepositoryAggregator<T> where T : IUser
    {
        private IRepository<IUser> userRepository;

        public UserRepositoryAggregator()
        {
            userRepository = new UserRepository<IUser>();
        }

        public bool CreateOrChoose(T item)
        {

            if (string.IsNullOrEmpty(item.FirstName) || string.IsNullOrEmpty(item.LastName))
            {
                return false;
            }

            var tempUser = userRepository.Get()
                .ToList()
                .Find(it => 
                    string.Equals(it.FirstName, item.FirstName) && 
                    string.Equals(it.LastName, item.LastName));

            if (tempUser == null)
            {
                userRepository.Add(item);
            }

            return true;
        }
    }
}