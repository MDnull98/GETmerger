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

      //private static ILog log = LogManager.GetLogger("LOGGER");

        public SQLInfoService(ITableQueryRepository tableQueryRepository, IDBQueryRepository dbQueryRepository)
        {
            _tableQueryRepository = tableQueryRepository;
            _dbQueryRepository = dbQueryRepository;
        }

        [MyErrorHandler]
        public List<DBQueryModel> GetDataBasesList()
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
    }
}
