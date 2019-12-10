using System.Collections.Generic;
using Task.CommonTypes.Interfaces;
using Task.StaticStorage;

namespace Task.ProcessingLogic
{
    public class MoneyMovementRepositoryAggregator<T> : IRepository<T>
        where T : IMoneyMovement
    {
        private IRepository<IMoneyMovement> moveMoneyRepository;

        public MoneyMovementRepositoryAggregator()
        {
            moveMoneyRepository = new MoneyMovementRepository<IMoneyMovement>();
        }

        public bool Add(T item)
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

        public bool Update(T item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
