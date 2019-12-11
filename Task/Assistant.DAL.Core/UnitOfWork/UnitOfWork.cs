using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositories;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;
using System;

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

        public bool Disposed { get; private set; }

        public UnitOfWork()
        {
            context = new AssistantContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            //if (!Disposed && disposing)
            //{
            //    context.Dispose();
            //}

            Disposed = true;
        }
    }
}
