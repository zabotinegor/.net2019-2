using Assistant.DAL.Core.Models;
using Assistant.DAL.Core.Repositories.EntityRepositoryInterfaces;

namespace Assistant.DAL.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        AssistantContext Context { get; }

        IMoneyMovementRepository MoneyMovementRepository { get; set; }

        IUserRepository UserRepository { get; set; }
    }
}
