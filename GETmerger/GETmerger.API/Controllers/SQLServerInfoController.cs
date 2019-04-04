using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GETmerger.API.Mapper;
using GETmerger.API.ViewModels;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;
using log4net;
using System.Web.Http.Filters;

namespace GETmerger.API.Controllers
{
    public class SQLServerInfoController : ApiController
    {
        // 1 GetDatabases()
        // 2 GetTables(int databaseID)
        // 3 GetMergeScript(int databaseID, int tableID)
        private static ILog log = LogManager.GetLogger("LOGGER");
        private ISQLInfoService _sqlinfo;
        private ActionFilterAttribute _actionfilter;

        public SQLServerInfoController(ISQLInfoService sqlinfo, ActionFilterAttribute actionfilter)
        {
            _sqlinfo = sqlinfo;
            _actionfilter = actionfilter;
        }

        [Route("api/databases")]
        public GenericResponse<IEnumerable<SQLInfoDatabaseVM>> GetDatabases()
        {
            var db = _sqlinfo.GetDataBasesList();
            return new GenericResponse<IEnumerable<SQLInfoDatabaseVM>>(db.Select(x => x.ToVMdatabases()));
        }

        [Route("api/databases/{databaseID}/tables")]
        public GenericResponse<IEnumerable<SQLInfoTablesVM>> GetTables(int databaseID)
        {
            var tablesVM = _sqlinfo.GetTables(databaseID);
            return new GenericResponse<IEnumerable<SQLInfoTablesVM>>(tablesVM.Select(t => t.ToVMtables()));
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            string script = _sqlinfo.GetMergeScript(databaseID, tableID).ToString();
            return new GenericResponse<string>(script);
        }
    }
}
