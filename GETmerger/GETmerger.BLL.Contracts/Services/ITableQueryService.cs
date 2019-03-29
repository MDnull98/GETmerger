using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface ITableQueryService
    {
        TableQueryModel GetbyDB(int? id);
    }
}
