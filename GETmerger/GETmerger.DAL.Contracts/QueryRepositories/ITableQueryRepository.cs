using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface ITableQueryRepository
    {
        TableDTO GetbyDB(int? id);
    }
}
