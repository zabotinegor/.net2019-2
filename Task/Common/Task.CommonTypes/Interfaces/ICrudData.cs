using System.Collections.Generic;

namespace Task.CommonTypes.Interfaces
{
    public interface ICrudData<T>
    {
        bool Add(T item);

        IEnumerable<T> Get();

        T Get(int id);

        bool Update(T item);

        bool Delete(int id);
    }
}