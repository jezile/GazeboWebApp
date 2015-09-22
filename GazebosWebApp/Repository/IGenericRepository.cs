using System.Collections.Generic;

namespace GazebosWebApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}