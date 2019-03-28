using System.Collections.Generic;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.Core.Repositories

{
    public interface IDBQueryRepository
    {
        List<DataBaseDTO> GetAll();
    }
}
