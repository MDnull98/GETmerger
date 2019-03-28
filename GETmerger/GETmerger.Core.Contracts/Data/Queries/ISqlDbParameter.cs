using System.Collections.Generic;
using System.Data;
using Dapper;

namespace GETmerger.Core.Contracts.Data.Queries
{
    public interface ISqlDbParameter : SqlMapper.IDynamicParameters, IEnumerable<IDbDataParameter>
    {
        void Add(IDbDataParameter value);
    }
}