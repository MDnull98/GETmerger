using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Repositories;
using GETmerger.DAL.EFContexts;

namespace GETmerger.DAL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private MergerContext databaseContext;

        public HistoryRepository(MergerContext context)
        {
            databaseContext = context;
        }
        public void Create(HistoryEntity item)
        {
            databaseContext.History.Add(item);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            HistoryEntity historyEntity = databaseContext.History.Find(id);
            if (historyEntity != null)
                databaseContext.History.Remove(historyEntity);
        }

        public HistoryEntity Get(int? id)
        {
            return databaseContext.History.Where(b => b.Id == id).FirstOrDefault();
        }

        public List<HistoryEntity> GetAll()
        {
            return databaseContext.History.ToList();
        }
    }
}
