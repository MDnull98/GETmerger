using System.Collections.Generic;
using System.Linq;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Mappers;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.BLL.Services
{
    public class SQLInfoService : ISQLInfoService
    {
        private IDBQueryRepository _databasesRepository { get; }
        private ITableQueryRepository _tablesQueryRepository { get; }
        private IScriptRepository _scriptQueryRepository { get; }

        public SQLInfoService(ITableQueryRepository tablesQueryRepository, IDBQueryRepository databasesRepository, IScriptRepository scriptQueryRepository)
        {
            _tablesQueryRepository = tablesQueryRepository;
            _databasesRepository = databasesRepository;
            _scriptQueryRepository = scriptQueryRepository;
        }

        public List<DataBaseQueryModel> GetDataBasesList()
        {
            var dbs = _databasesRepository.GetDataBases();

            return dbs.Select(r => r.ToQueryDBModel()).ToList();
        }

        public List<TableQueryModel> GetTables(int databaseid)
        {
                var tables = _tablesQueryRepository.GetTables(databaseid);

                return tables.Select(x => x.ToQueryTableModel()).ToList();
        }

        public string MergeScript(int databaseID, int tableID)
        {
            return _scriptQueryRepository.GetScript(databaseID, tableID).ToString();
        }
    }
}
