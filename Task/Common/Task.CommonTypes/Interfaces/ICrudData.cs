using System.Collections.Generic;

namespace Task.CommonTypes.Interfaces
{
    public interface ICrudData<T> where T : IMoneyMovement
    {
        bool Add(T item);

        IEnumerable<T> Get();

        T Get(int id);

        T Update(T item);

        bool Delete(int id);
    }
}