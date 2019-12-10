using System;
using System.Collections.Generic;

namespace Task.CommonTypes.Interfaces
{
    public interface IRepository<T>
    {
        int Add(T item);

        IEnumerable<T> Get();

        T Get(int id);

        T Update(int id, T item);

        bool Delete(int id);
    }
}