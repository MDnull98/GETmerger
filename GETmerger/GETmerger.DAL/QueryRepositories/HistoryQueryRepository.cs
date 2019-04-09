using System.Collections.Generic;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class HistoryQueryRepository : BaseQueryRepository,IHistoryQueryRepository
    {
        public HistoryQueryRepository(string dbconnection)
            : base(dbconnection)
        {

        }

        public List<HistoryDTO> GetHistory()
        {
            const string sql ="USE History; SELECT DatabaseId,TableId,GenerateScript,AddDate From dbo.HistoryEntities;";

            return GetList<HistoryDTO>(sql);
        }
    }
}