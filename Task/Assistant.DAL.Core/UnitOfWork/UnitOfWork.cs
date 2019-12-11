using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositories;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;

namespace Assistant.DAL.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssistantContext context;
        private IMoneyMovementRepository moneyMovementRepository;
        private IUserRepository userRepository;
        
        public AssistantContext Context => context;

        public IMoneyMovementRepository MoneyMovementRepository 
        { 
            get => moneyMovementRepository ?? new MoneyMovementRepository(context); 
            set => moneyMovementRepository = value; 
        }

        public IUserRepository UserRepository 
        { 
            get => userRepository ?? new UserRepository(context); 
            set => userRepository = value; 
        }

        public UnitOfWork()
        {
            context = new AssistantContext();
        }
    }
}
