using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class SQLInfoRepository: BaseQueryRepository,ITableQueryRepository, IDBQueryRepository,
    {
        public SQLInfoRepository(string dbconnection)
            : base(dbconnection)
        {

        }
        public List<DataBaseDTO> GetDataBases()
        {
            var sql = "SELECT[name], database_id as id from sys.databases";

            return GetList<DataBaseDTO>(sql);
        }

        public List<TableDTO> GetTables(int? databaseId)
        {
            //bases = db1.Query<TableDTO>("SELECT table_name FROM information_schema.tables where table_schema='<"+id+">'").ToList();
            var sql = $"SELECT table_name FROM information_schema.tables where table_schema='<{databaseId}>'";
            var res = GetList<TableDTO>(sql);
            return res;
        }
    }
}
