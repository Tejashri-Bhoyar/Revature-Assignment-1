using System.Collections.Generic;

namespace Core
{
    public interface IRepository<T>
    {
        void Add(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Remove(int id);
    }
}
