using System.Collections.Generic;
using GETmerger.Core.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IDBQueryRepository: IBaseQueryRepository
    {
        List<DataBaseDTO> GetAll();
    }
}
