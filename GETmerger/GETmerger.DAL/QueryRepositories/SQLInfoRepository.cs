using System.Collections.Generic;
using System.Data.SqlClient;
using GETmerger.Core.Core.Common.Data.Queries;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class SQLInfoRepository: BaseQueryRepository,ITableQueryRepository, IDBQueryRepository, IScriptRepository
    {
        public SQLInfoRepository(string dbconnection)
            : base(dbconnection)
        {

        }

        public List<DataBaseDTO> GetDataBases()
        {
            //get db names
            const string sql = "SELECT database_id as id, name FROM    sys.databases  WHERE name NOT IN('master', 'tempdb', 'model', 'msdb')";

            return GetList<DataBaseDTO>(sql);
        }

        public List<TableDTO> GetTables(int databaseId)
        {
            //get table names via database_id
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
            // get merge-script via database_id AND table_id
            var sql = $@"DECLARE @DataBaseName nvarchar(100)
                         Select @DataBaseName = [name]
                         from sys.databases
                         where database_id = @databaseid
                         DECLARE @TableName nvarchar(100)
                         Select @TableName = [name]
                         from sys.tables where [object_id] = @tableid
                         DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName + ' Select '+@TableName+' = [name] 
                         from sys.tables where [object_id] = 341576255; exec sp_generate_merge '+@TableName+''
                         exec  sp_executesql @Query;";

            var param = new SqlDbParameter()
            {
                new SqlParameter("databaseId", databaseID),
                new SqlParameter("tableid", tableID)
            };

            return Get<string>(sql,param);
        }
    }
}