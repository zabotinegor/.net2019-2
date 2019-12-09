using System;
using System.Collections.Generic;

namespace Task.CommonTypes.Interfaces
{
    public interface IRepository<T>
    {
        bool Add(T item);

        IEnumerable<T> Get();

        T Get(int id);

        bool Update(T item);

        bool Delete(int id);
    }
}