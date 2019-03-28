using System.Collections.Generic;
using GETmerger.DAL.Contracts.Repositories;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.Core.Repositories

{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T Get(string dbname);
    }
}
