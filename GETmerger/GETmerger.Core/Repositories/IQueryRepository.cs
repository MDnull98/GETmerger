using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.DAL.Contracts.Repositories
{
    public interface IQueryRepository<T> where T: class
    {
      List<T> GetAll();
      T Get(int? id);
    }
}
