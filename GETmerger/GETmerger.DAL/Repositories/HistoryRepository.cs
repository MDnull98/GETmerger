using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Repositories;
using GETmerger.DAL.EFContexts;

namespace GETmerger.DAL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private MergerContext _databaseContext;

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
            {
                _databaseContext.History.Remove(historyEntity);
            }
        }

        public HistoryEntity Get(int? id)
        {
            return _databaseContext.History.Where(b => b.Id == id).FirstOrDefault();
        }

        public List<HistoryEntity> GetAll()
        {
            return _databaseContext.History.ToList();
        }
    }
}
