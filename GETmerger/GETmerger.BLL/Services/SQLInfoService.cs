using System;
using System.Collections.Generic;
using System.Linq;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Mappers;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.BLL.Services
{
    public class SQLInfoService : ISQLInfoService
    {
        private IDBQueryRepository _db { get; }
        private ITableQueryRepository _tableQuery { get; }
        private IScriptRepository _scriptQuery { get; }
        private IHistoryRepository _historyRepository { get; }

        public SQLInfoService(ITableQueryRepository tableQuery, IDBQueryRepository db, IScriptRepository scriptQuery, IHistoryRepository historyRepository)
        {
            _tableQuery = tableQuery;
            _db = db;
            _scriptQuery = scriptQuery;
            _historyRepository = historyRepository;
        }

        public List<DBQueryInputModel> GetDataBasesList()
        {
            var dbs = _db.GetDataBases();

            return dbs.Select(r => r.ToQueryDBModel()).ToList();
        }

        public IEnumerable<TableQueryInputModel> GetTables(int databaseid)
        {
                var tables = _tableQuery.GetTables(databaseid);

                return tables.Select(x => x.ToQueryTableModel());
        }
        public string GetMergeScript(int databaseID, int tableID)
        {
            string xml = _scriptQuery.GetMergeScript(databaseID, tableID).ToString();
            string stringsql = XMLParser.GetSQL(xml);

            DateTime dt = DateTime.Now;

            _historyRepository.Create(new HistoryEntity
            {
                DatabaseId = databaseID,
                TableId = tableID,
                GenerateScript = stringsql,
                AddDate = dt
            });

            return stringsql;
        }
    }
}
