using System.Collections.Generic;
using System.Data.SqlClient;
using GETmerger.Core.Core.Common.Data.Queries;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class SqlInfoQueryRepository: BaseQueryRepository,ITableQueryRepository, IDBQueryRepository, IScriptQueryRepository
    {
        public SqlInfoQueryRepository(string dbconnection)
            : base(dbconnection)
        {

        }

        public List<DataBaseDTO> GetDataBases()
        {
            const string sql = "SELECT database_id as id, name FROM    sys.databases  WHERE name NOT IN('master', 'tempdb', 'model', 'msdb')";

            return GetList<DataBaseDTO>(sql);
        }

        public List<TableDTO> GetTables(int databaseId)
        {
            var sql = $@"DECLARE @DataBaseName nvarchar(100) Select @DataBaseName = [name]
                         from sys.databases where database_id = @databaseId
                         DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName + '
                         SELECT [object_id] as id, name  FROM sys.Tables WHERE name NOT IN(''sysdiagrams'')' 
                         exec  sp_executesql @Query;";

            var param = new SqlDbParameter()
            {
                new SqlParameter("databaseId", databaseId)
            };

            return GetList<TableDTO>(sql, param);
        }

        public string GetMergeScript(int databaseID, int tableID)
        {
            var sql = @"DECLARE @DataBaseName nvarchar(100);
                         Select @DataBaseName = [name]
                         from sys.databases
                         where database_id = 6;
                         DECLARE @TableName nvarchar(100);
                         Select @TableName = [name]
                         from sys.tables where [object_id] = 341576255;
                         DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName +'; '+ 'exec sp_generate_merge ''Teachers'';';
                         exec  sp_executesql @Query;";

            var param = new SqlDbParameter()
            {
                new SqlParameter("databaseID", databaseID),
                new SqlParameter("tableID", tableID)
            };

            return Get<string>(sql,param);
        }
    }
}