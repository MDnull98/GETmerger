using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class SQLInfoRepository: BaseQueryRepository,ITableQueryRepository, IDBQueryRepository, IScriptRepository
    {
        public const string connectionString = @"data source=MDNULL\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        public readonly SqlConnection connection = new SqlConnection(connectionString);

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

            connection.Open();
            var command = new SqlCommand(sql, connection);
            var DBid = new SqlParameter("@databaseid", databaseId);

            command.Parameters.Add(DBid);
            command.ExecuteNonQuery();

            return GetList<TableDTO>(sql);
        }

        public string GetMergeScript(int databaseID, int tableID)
        {
            // get merge-script via database_id AND table_id
            var sql = $@"DECLARE @DataBaseId numeric(10)
                         DECLARE @DataBaseName nvarchar(100)
                         Select @DataBaseName = [name]
                         from sys.databases
                         where database_id = @databaseid
                         DECLARE @TableId numeric(10)
                         DECLARE @TableName nvarchar(100)
                         Select @TableName = [name]
                         from sys.tables where [object_id] = @tableid
                         DECLARE @Query nvarchar(max) = 'USE ' + @DataBaseName + ' Select '+@TableName+' = [name] 
                         from sys.tables where [object_id] = 341576255; exec sp_generate_merge '+@TableName+''
                         exec  sp_executesql @Query;";

            var command = new SqlCommand(sql, connection);
            var DBid = new SqlParameter("@databaseid", databaseID);
            var Tableid = new SqlParameter("@tableid", tableID);

            command.Parameters.Add(DBid);
            command.Parameters.Add(Tableid);
            command.ExecuteNonQuery();
            connection.Close();
            return Get<string>(sql);
        }
    }
}