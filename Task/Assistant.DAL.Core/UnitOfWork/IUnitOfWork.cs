using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;
using System;

namespace Assistant.DAL.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AssistantContext Context { get; }

        IMoneyMovementRepository MoneyMovementRepository { get; set; }

        IUserRepository UserRepository { get; set; }

        bool Disposed { get; }
    }
}
