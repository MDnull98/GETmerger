using System.Collections.Generic;
using System.Linq;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Repositories;
using GETmerger.DAL.EFContexts;

namespace GETmerger.DAL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly MergerContext _databaseContext;

        public HistoryRepository(MergerContext context)
        {
            _databaseContext = context;
        }

        public void Create(HistoryEntity item)
        {
            _databaseContext.History.Add(item);
            _databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            HistoryEntity historyEntity = _databaseContext.History.Find(id);
            if (historyEntity != null)
                _databaseContext.History.Remove(historyEntity);
        }

        public HistoryEntity Get(int? id)
        {
            return _databaseContext.History.FirstOrDefault(b => b.Id == id);
        }

        public List<HistoryEntity> GetAll()
        {
            return _databaseContext.History.ToList();
        }
    }
}
