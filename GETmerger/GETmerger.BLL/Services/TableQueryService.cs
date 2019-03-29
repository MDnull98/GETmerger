using System.Activities;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.BLL.Services
{
    public class TableQueryService : ITableQueryService
    {
        private ITableQueryRepository _tableQuery { get; }

        public TableQueryService(ITableQueryRepository tableQuery)
        {
            _tableQuery = tableQuery;
        }

        public TableQueryModel GetbyDB(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id");
            }
            else
            {
                TableDTO table = _tableQuery.GetbyDB(id);
                return new TableQueryModel
                {
                    Id = table.Id,
                    Name = table.Name
                };
            }
        }
    }
}
