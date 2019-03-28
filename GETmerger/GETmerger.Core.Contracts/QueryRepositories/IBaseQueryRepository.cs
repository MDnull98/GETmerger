using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.Core.Contracts.Data.Queries;

namespace GETmerger.Core.Contracts.QueryRepositories
{
    public interface IBaseQueryRepository
    {
        T Get<T>(string query, ISqlDbParameter parameter);
        List<T> GetList<T>(string query, ISqlDbParameter parameter);
    }
}
