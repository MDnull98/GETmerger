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
        private IScriptRepository _scriptQuery { get; }

        public SQLInfoService(ITableQueryRepository tableQuery, IDBQueryRepository db, IScriptRepository scriptQuery)
        {
            _tableQuery = tableQuery;
            _db = db;
            _scriptQuery = scriptQuery;
        }

        public List<DataBaseQueryModel> GetDataBasesList()
        {
            var dbs = _db.GetDataBases();

            return dbs.Select(r => r.ToQueryDBModel()).ToList();
        }

        public IEnumerable<TableQueryModel> GetTables(int databaseid)
        {
                var tables = _tableQuery.GetTables(databaseid);

                return tables.Select(x => x.ToQueryTableModel());
        }

        public string MergeScript(int databaseID, int tableID)
        {
            return _scriptQuery.GetScript(databaseID, tableID);
        }
    }
}
