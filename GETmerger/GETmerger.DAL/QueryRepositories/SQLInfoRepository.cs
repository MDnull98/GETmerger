using System.Collections.Generic;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;
using log4net;

namespace GETmerger.DAL.QueryRepositories
{
    public class SQLInfoRepository: BaseQueryRepository,ITableQueryRepository, IDBQueryRepository, IScriptRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ApiLog");
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
                         from sys.databases where database_id = {databaseId}
                         DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName + '
                         SELECT [object_id] as id, name  FROM sys.Tables WHERE name NOT IN(''sysdiagrams'')' 
                         exec  sp_executesql @Query;";

            return GetList<TableDTO>(sql);
        }

        public ScriptModel GetMergeScript(int databaseID, int tableID)
        {
            // get merge-script via database_id AND table_id
            //var sql = $@"DECLARE @DataBaseId numeric(10)
            //             DECLARE @DataBaseName nvarchar(100)
            //             Select @DataBaseName = [name]
            //             from sys.databases
            //             where database_id = {databaseID}
            //             DECLARE @TableId numeric(10)
            //             DECLARE @TableName nvarchar(100)
            //             Select @TableName = [name]
            //             from sys.tables where [object_id] = {tableID}
            //             DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName + ' Select '+@TableName+' = [name] 
            //             from sys.tables where [object_id] = 341576255; exec sp_generate_merge '+@TableName+''
            //             exec  sp_executesql @Query;";
            var sql = $@"use SchoolContext; exec sp_generate_merge Pupils";;

            return Get<ScriptModel>(sql);
        }
    }
}