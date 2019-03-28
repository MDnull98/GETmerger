using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.Core.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T Get(int? id);

        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
