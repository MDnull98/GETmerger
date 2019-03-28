using GETmerger.Core.Repositories;
using GETmerger.DAL.Contracts.Models.DomainModels;

namespace GETmerger.DAL.Contracts.Repositories
{
    public interface IHistoryRepository:IRepository<HistoryEntity>
    {
        string ExecQuery(string dbname, string tablename);
    }
}
