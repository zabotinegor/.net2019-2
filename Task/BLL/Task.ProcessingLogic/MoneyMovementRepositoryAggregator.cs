using System.Collections.Generic;
using Task.CommonTypes.Interfaces;
using Task.StaticStorage;

namespace Task.ProcessingLogic
{
    public class MoneyMovementRepositoryAggregator<T> : IRepository<T>
        where T : IMoneyMovement
    {
        private IRepository<T> moveMoneyRepository;

        public MoneyMovementRepositoryAggregator()
        {
            moveMoneyRepository = new MoneyMovementRepository<T>();
        }

        public IEnumerable<T> Get()
        {
            return moveMoneyRepository.Get();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(int id, T item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Add(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
