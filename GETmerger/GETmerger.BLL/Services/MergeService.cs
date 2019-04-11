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
        private readonly IScriptRepository _scriptQueryRepository;
        private readonly IHistoryRepository _historyRepository;

        public MergeService(IScriptRepository scriptQueryRepository, IHistoryRepository historyRepository)
        {
            _scriptQueryRepository = scriptQueryRepository;
            _historyRepository = historyRepository;
        }
        public string GetMergeScript(int databaseID, int tableID)
        {

            var xml = _scriptQueryRepository.GetMergeScript(databaseID, tableID);
            var stringSql = XMLParser.GetSQL(xml);
            var dt = DateTime.Now;

            var historyEntity = new HistoryEntity
            {
                DatabaseId = databaseID,
                TableId = tableID,
                GenerateScript = stringSql,
                AddDate = dt
            };

            _historyRepository.Create(historyEntity);

            return stringSql;
        }
    }
}
