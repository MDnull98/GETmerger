using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc.Html;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.BLL.Services
{
    public class HistoryService : IHistoryService
    {
        private IHistoryRepository _historyRepository { get; }
        private IScriptRepository _scriptRepository { get; }

        public HistoryService(IHistoryRepository historyRepository, IScriptRepository scriptRepository)
        {
            _historyRepository = historyRepository;
            _scriptRepository = scriptRepository;
        }

        public IEnumerable<HistoryInputModel> GetHistory()
        {
            var DBList = new List<HistoryInputModel>();
            var list = _historyRepository.GetAll().ToList();

            foreach (HistoryEntity item in list)
            {
                var dbDTO = new HistoryInputModel
                {
                    Id =item.Id,
                    DatabaseId =item.DatabaseId,
                    TableId = item.TableId,
                    GenerateScript = item.GenerateScript,
                    AddDate = item.AddDate
                };

                DBList.Add(dbDTO);
            }

            return DBList;
        }

        public HistoryInputModel Get(int id)
        {
            var historyEntity = _historyRepository.Get(id);
                return new HistoryInputModel
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

            if (historyEntity != null)
                _historyRepository.Delete(id);
        }
    }
}
