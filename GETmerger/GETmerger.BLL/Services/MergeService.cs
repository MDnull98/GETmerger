using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.BLL.Contracts.Services;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.BLL.Services
{
    public class MergeService : IMergeService
    {
        private readonly IScriptQueryRepository _scriptQueryQueryRepository;
        private readonly IHistoryRepository _historyQueryRepository;

        public MergeService(IScriptQueryRepository scriptQueryQueryRepository, IHistoryRepository historyQueryRepository)
        {
            _scriptQueryQueryRepository = scriptQueryQueryRepository;
            _historyQueryRepository = historyQueryRepository;
        }
        public string GetMergeScript(int databaseID, int tableID)
        {
            var xml = _scriptQueryQueryRepository.GetMergeScript(databaseID, tableID);
            var stringSql = XMLParser.GetSQL(xml);
            var dt = DateTime.Now;

            var historyEntity = new HistoryEntity
            {
                DatabaseId = databaseID,
                TableId = tableID,
                GenerateScript = stringSql,
                AddDate = dt
            };

            _historyQueryRepository.Create(historyEntity);

            return stringSql;
        }
    }
}
