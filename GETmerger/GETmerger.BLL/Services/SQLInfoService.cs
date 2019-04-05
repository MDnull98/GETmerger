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
        private IDBQueryRepository _dbQueryRepository { get; }
        private ITableQueryRepository _tableQueryRepository { get; }
        private IScriptRepository _scriptQueryRepository { get; }
        private IHistoryRepository _historyRepository { get; }

        public SQLInfoService(ITableQueryRepository tableQueryRepository, IDBQueryRepository dbQueryRepository, IScriptRepository scriptQueryRepository, IHistoryRepository historyRepository)
        {
            _tableQueryRepository = tableQueryRepository;
            _dbQueryRepository = dbQueryRepository;
            _scriptQueryRepository = scriptQueryRepository;
            _historyRepository = historyRepository;
        }

        public List<DBQueryInputModel> GetDataBasesList()
        {
            var dbs = _dbQueryRepository.GetDataBases();

            return dbs.Select(r => r.ToQueryDBModel()).ToList();
        }

        public List<TableQueryInputModel> GetTables(int databaseid)
        {
                var tables = _tableQueryRepository.GetTables(databaseid);

                return tables.Select(x => x.ToQueryTableModel()).ToList();
        }
        public string GetMergeScript(int databaseID, int tableID)
        {
            string xml = _scriptQueryRepository.GetMergeScript(databaseID, tableID).Name;
            string stringsql = XMLParser.GetSQL(xml);

            DateTime dt = DateTime.Now;

            _historyRepository.Create(new HistoryEntity
            {
                DatabaseId = databaseID,
                TableId = tableID,
                GenerateScript = "",
                AddDate = dt
            });

            return stringsql;
        }
    }
}
