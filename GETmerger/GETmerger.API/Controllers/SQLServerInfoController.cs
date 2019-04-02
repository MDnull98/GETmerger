using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GETmerger.API.Mapper;
using GETmerger.API.ViewModels;
using GETmerger.BLL.Contracts.Models.Output;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;

namespace GETmerger.API.Controllers
{
    public class SQLServerInfoController : ApiController
    {
        // 1 GetDatabases()
        // 2 GetTables(int databaseID)
        // 3 GetMergeScript(int databaseID, int tableID)
        private ISQLInfoService _sqlinfo;

        public SQLServerInfoController(ISQLInfoService sqlinfo)
        {
            _sqlinfo = sqlinfo;
        }

        [Route("api/databases")]
        public GenericResponse<IEnumerable<SQLInfoDatabaseVM>> GetDatabases()
        {
            var db = _sqlinfo.GetDataBasesList();
            return new GenericResponse<IEnumerable<SQLInfoDatabaseVM>>(db.Select(x => x.ToVMdatabases()));
        }

        [Route("api/databases/{databaseId}/tables")]
        public GenericResponse<IEnumerable<SQLInfoTablesVM>> GetTables(int databaseId)
        {
            var tablesVM = _sqlinfo.GetTables(databaseId);
            return new GenericResponse<IEnumerable<SQLInfoTablesVM>>(tablesVM.Select(t => t.ToVMtables()));
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript([FromUri]int databaseID, [FromUri] int tableID)
        {
            //correct
            var tablesVM = _sqlinfo.GetTables(databaseID);
            return new GenericResponse<string>("databse2");
        }
    }
}
