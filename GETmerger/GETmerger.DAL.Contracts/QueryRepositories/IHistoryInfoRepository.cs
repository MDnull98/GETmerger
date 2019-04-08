using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.Models.DomainModels;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IHistoryInfoRepository
    {
        List<HistoryEntity> GetHistory();
    }
}
