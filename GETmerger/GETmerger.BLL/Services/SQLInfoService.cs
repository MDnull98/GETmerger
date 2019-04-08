using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GETmerger.API.Logger;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Mappers;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;
using log4net;

namespace GETmerger.BLL.Services
{
    public class SQLInfoService : ISQLInfoService
    {
        private readonly IDBQueryRepository _dbQueryRepository;
        private readonly ITableQueryRepository _tableQueryRepository;
        private readonly IScriptRepository _scriptQueryRepository;
        private readonly IHistoryRepository _historyRepository;

        private static ILog log = LogManager.GetLogger("LOGGER");

        public SQLInfoService(ITableQueryRepository tableQueryRepository, IDBQueryRepository dbQueryRepository, IScriptRepository scriptQueryRepository, IHistoryRepository historyRepository)
        {
            _tableQueryRepository = tableQueryRepository;
            _dbQueryRepository = dbQueryRepository;
            _scriptQueryRepository = scriptQueryRepository;
            _historyRepository = historyRepository;
        }
        [MyErrorHandler]
        public List<DBQueryInputModel> GetDataBasesList()
        {
            var dbs = _dbQueryRepository.GetDataBases();
            return dbs.Select(r => r.ToQueryDBModel()).ToList();
        }
        [LoggingFilter]
        public List<TableQueryInputModel> GetTables(int databaseId)
        {
                var tables = _tableQueryRepository.GetTables(databaseId);

                return tables.Select(x => x.ToQueryTableModel()).ToList();
        }

        public string GetMergeScript(int databaseID, int tableID)
        {
            var xml = _scriptQueryRepository.GetMergeScript(databaseID, tableID);
            var stringSql = XMLParser.GetSQL(xml);

            var dt = DateTime.Now;

            _historyRepository.Create(new HistoryEntity
            {
                DatabaseId = databaseID,
                TableId = tableID,
                GenerateScript = XMLParser.GetSQL(xml),
                AddDate = dt
            });
            return stringSql;
        }
    }
}
