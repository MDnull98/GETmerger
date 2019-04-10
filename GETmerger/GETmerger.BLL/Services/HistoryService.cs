using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Mappers;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.BLL.Services
{
    public class HistoryService : IHistoryService
    {
        private IHistoryRepository _historyRepository { get; }
        private IScriptRepository _scriptRepository { get; }
        private IHistoryQueryRepository _historyQueryRepository {get;}

        public HistoryService(IHistoryRepository historyRepository, IScriptRepository scriptRepository, IHistoryQueryRepository historyQueryRepository)
        {
            _historyRepository = historyRepository;
            _scriptRepository = scriptRepository;
            _historyQueryRepository = historyQueryRepository;
        }

        public HistoryOutputModel Get(int id)
        {
            var historyEntity = _historyRepository.Get(id);

                return new HistoryOutputModel
                {
                    Id = historyEntity.Id,
                    DatabaseId = historyEntity.DatabaseId,
                    TableId = historyEntity.TableId,
                    GenerateScript = historyEntity.GenerateScript,
                    AddDate = historyEntity.AddDate
                };
        }

        public void Delete(int id)
        {
            var historyEntity = _historyRepository.Get(id);

            if (historyEntity == null)
            {
               throw new HttpResponseException(HttpStatusCode.NotFound);
            }

           _historyRepository.Delete(id);
        }

        public IEnumerable<HistoryOutputModel> GetHistory()
        {
            var dbs = _historyQueryRepository.GetHistory();

            return dbs.Select(r => r.ToHistoryModel()).ToList();
        }
    }
}
