using System.Collections.Generic;
using AppCore.Models;

namespace AppCore.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IList<T> GetAll();
        T GetBy(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void AddRange(IList<T> entities);
        void UpdateRange(IList<T> entities);
        void DeleteRange(IList<T> entities);

        bool Exists(int id);
    }
}