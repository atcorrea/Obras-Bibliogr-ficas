using System;
using System.Collections.Generic;


namespace GuideTest.Repository
{
    public interface IRepository<T>
    {
        T Get(T item);

        T GetWhere(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllWhere(Func<T, bool> predicate);

        T Add(T item);

        T Remove(T item);

        bool Commit();
    }
}
