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

        public SQLInfoService(ITableQueryRepository tableQuery, IDBQueryRepository db)
        {
            _tableQuery = tableQuery;
            _db = db;
        }


        public List<DataBaseQueryModel> GetDataBasesList()
        {
            var dbs = _db.GetDataBases();

            return dbs.Select(r => r.ToQueryDBModel()).ToList();
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

                return tables.Select(x => x.ToQueryTableModel());
            }
        }
    }
}
