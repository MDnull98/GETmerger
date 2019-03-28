using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GETmerger.Core.QueryRepositories;
using GETmerger.Core.Repositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class BaseRepository:BaseQueryRepository, IDBQueryRepository
    {
        public BaseRepository(string dbconnection)
            :base(dbconnection)
        {

        }


        public List<DataBaseDTO> GetAll()
        {
            var sql = "SELECT[name], database_id as id from sys.databases";

            return GetList<DataBaseDTO>(sql);
        }
    }
}
