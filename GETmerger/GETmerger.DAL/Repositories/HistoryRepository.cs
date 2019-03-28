using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.EF;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Repositories;

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
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HistoryEntity Get(int? id)
        {
            throw new NotImplementedException();
        }

        public List<HistoryEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(HistoryEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
