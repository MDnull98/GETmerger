using System.Collections.Generic;

namespace GETmerger.Core.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T Get(int? id);

        void Create(T item);
        void Delete(int id);
    }
}
