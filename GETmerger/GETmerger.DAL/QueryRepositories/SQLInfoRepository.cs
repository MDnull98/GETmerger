using System.Collections.Generic;
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
            //get db names from master
            const string sql = "SELECT [name], database_id as id FROM    sys.databases  WHERE name NOT IN('master', 'tempdb', 'model', 'msdb')";

            return GetList<DataBaseDTO>(sql);
        }
        public List<TableDTO> GetTables(int databaseId)
        {
            //get tables name via id
            var sql = $@"DECLARE @DatabaseName nvarchar(100) 
                         Select @DatabaseName = [name] from sys.databases
                         where database_id = {databaseId} 
                         DECLARE @Query nvarchar(max) = 'USE ' + @DatabaseName + ' SELECT [name],object_id as id FROM sys.Tables WHERE name NOT IN(''sysdiagrams'')'
                         exec  sp_executesql @Query;";

            return GetList<TableDTO>(sql);
        }

        public ScriptModel GetScript(int databaseID, int tableID)
        {
            //get merge-sript via database_id and table_id
            var sql = $@"DECLARE @DataBaseId numeric(10)
                         DECLARE @DataBaseName nvarchar(100)
                         Select @DataBaseName = [name]
                         from sys.databases
                         where database_id = {databaseID}
                         DECLARE @TableId numeric(10)
                         DECLARE @TableName nvarchar(100)
                         Select @TableName = [name]
                         from sys.tables where [object_id] = {tableID}
                         DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName + ' USE @DataBaseName GO exec sp_generate_merge '+@TableName+''')'
                         exec  sp_executesql @Query;";

            return Get<ScriptModel>(sql);
        }

    }
}