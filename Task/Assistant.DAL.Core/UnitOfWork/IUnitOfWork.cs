using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;
using System;
using System.Threading.Tasks;

namespace Assistant.DAL.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AssistantContext Context { get; }
        
        IUserRepository UserRepository { get; set; }

        IMoneyMovementRepository MoneyMovementRepository { get; set; }

        void SaveChanges();

        Task SaveChangesAsync();

        bool Disposed { get; }
    }
}
