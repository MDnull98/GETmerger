using System.Collections.Generic;
using System.Web.Http;
using GETmerger.BLL.Contracts.Models.Output;
using GETmerger.Core.Models;

namespace GETmerger.API.Controllers
{
    public class SQLServerInfoController : ApiController
    {
        // 1 GetDatabases()
        // 2 GetTables(string databaseName)
        // 3 GetMergeScript(string databaseName, string tableName)

        [Route("api/databases")]
        public GenericResponse<IEnumerable<DatabaseOutputModel>> GetDatabases()
        {
            return new GenericResponse<IEnumerable<DatabaseOutputModel>>(null);
        }

        [Route("api/tables")]
        public GenericResponse<IEnumerable<string>> GetTables(string databaseName)
        {
            return new GenericResponse<IEnumerable<string>>(new[] { "databse1", "databse2" });
        }

        [Route("api/merge-script")]
        public GenericResponse<string> GetMergeScript(string databaseName, string tableName)
        {
            return new GenericResponse<string>("databse2");
        }

    }
}
