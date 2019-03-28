using System.Collections.Generic;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface ITableQueryRepository<T>
    {
        List<T> GetAll(string dbname);
        T Get(string dbname,string tablename);
    }
}
