using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IHistoryQueryRepository
    {
        List<HistoryDTO> GetHistory();
    }
}
