using System.Data.SqlClient;
using GETmerger.Core.Core.Common.Data.Queries;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class ScriptQueryRepository : BaseQueryRepository, IScriptQueryRepository
    {
        public ScriptQueryRepository(string dbconnection)
            : base(dbconnection)
        {

        }

        public string GetMergeScript(int databaseID, int tableID)
        {
         const string query = @"DECLARE @DataBaseName nvarchar(100);
                         Select @DataBaseName = [name]
                         from sys.databases
                         where database_id = 6;
						 DECLARE @Query nvarchar(max) = 'USE '+@DataBaseName+';
                         DECLARE @TableName nvarchar(100); Select @TableName = [name] 
                         from sys.tables where [object_id] = 277576027; exec sp_generate_merge @TableName';
                         exec  sp_executesql @Query;";

            var param = new SqlDbParameter()
            {
                new SqlParameter("databaseID", databaseID),
                new SqlParameter("tableID", tableID)
            };

            return Get<string>(query, param);
        }
    }
}
