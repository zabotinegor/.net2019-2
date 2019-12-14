using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;
using Assistant.DAL.Core.Repositories.GenericRepository;

namespace Assistant.DAL.Core.Repositories.EntityRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AssistantContext context) : base(context)
        {
        }
    }
}
