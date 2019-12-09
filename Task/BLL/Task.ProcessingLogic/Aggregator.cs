using Task.CommonTypes.Interfaces;
using Task.StaticStorage;

namespace Task.ProcessingLogic
{
    class Aggregator
    {
        private IRepository<IMoneyMovement> moveMoneyRepository;
        private IRepository<IUser> userRepository;

        public Aggregator()
        {
            moveMoneyRepository = new MoneyMovementRepository<IMoneyMovement>();
            userRepository = new UserRepository<IUser>();
        }

    }
}
