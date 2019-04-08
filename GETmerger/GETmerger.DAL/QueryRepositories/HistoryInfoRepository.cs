using System.Collections.Generic;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class HistoryInfoRepository : BaseQueryRepository,IHistoryInfoRepository
    {
        public HistoryInfoRepository(string dbconnection)
            : base(dbconnection)
        {

        }

        public List<HistoryEntity> GetHistory()
        {
            const string sql ="USE History; SELECT DatabaseId,TableId,GenerateScript,AddDate From dbo.HistoryEntities;";

            return GetList<HistoryEntity>(sql);
        }
    }
}