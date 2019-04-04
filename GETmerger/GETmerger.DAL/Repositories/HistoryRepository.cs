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
        private MergerContext db;

        public HistoryRepository(MergerContext context)
        {
            db = context;
        }
        public void Create(HistoryEntity item)
        {
            db.History.Add(item);

            //or ExecuteSqlCommand
        }

        public void Delete(int id)
        {
            HistoryEntity historyEntity = db.History.Find(id);
            if (historyEntity != null)
                db.History.Remove(historyEntity);
        }

        public HistoryEntity Get(int? id)
        {
            return db.History.Where(b => b.Id == id).FirstOrDefault();
        }

        public List<HistoryEntity> GetAll()
        {
            return db.History.ToList();
        }

        public void Update(HistoryEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
