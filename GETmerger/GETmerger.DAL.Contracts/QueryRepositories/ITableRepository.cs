using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.Models;
using  GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface ITableQueryRepository:IQueryRepository<TableName>
    {

    }
}
