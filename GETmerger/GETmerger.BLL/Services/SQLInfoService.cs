using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Mappers;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.BLL.Services
{
    public class SQLInfoService : ISQLInfoService
    {
        private IDBQueryRepository _db { get; }
        private ITableQueryRepository _tableQuery { get; }

        public SQLInfoService(IDBQueryRepository db, ITableQueryRepository tableQuery)
        {
            _db = db;
            _tableQuery = tableQuery;
        }
        public List<DataBaseQueryModel> GetDataBasesList()
        {
            List<DataBaseQueryModel> DBList = new List<DataBaseQueryModel>();
            List<DataBaseDTO> list = _db.GetDataBases().ToList();

            foreach (DataBaseDTO item in list)
            {
                DataBaseQueryModel dbDTO = new DataBaseQueryModel
                {
                    Id = item.Id,
                    Name = item.Name
                };

                DBList.Add(dbDTO);
            }

            return DBList;
        }

        public IEnumerable<TableQueryModel> GetTables(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id");
            }
            else
            {
                var tables = _tableQuery.GetTables(id);

                return tables.Select(x => x.ToQueryModel());
            }
        }
    }
}
