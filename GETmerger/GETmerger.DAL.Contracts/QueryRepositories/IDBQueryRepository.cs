using System.Collections.Generic;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IDBQueryRepository
    {
        List<DataBaseDTO> GetDataBases();
    }
}
