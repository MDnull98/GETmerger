using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using GETmerger.API.Mapper;
using GETmerger.API.ViewModels;
using GETmerger.BLL.Contracts.Models.Output;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;
using log4net;
using log4net.Repository.Hierarchy;
using System.Web.Http;

namespace GETmerger.API.Controllers
{
    public class SQLServerInfoController : ApiController
    {
        // 1 GetDatabases()
        // 2 GetTables(int databaseID)
        // 3 GetMergeScript(int databaseID, int tableID)
        private static ILog log = LogManager.GetLogger("LOGGER");
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

        [Route("api/databases/{databaseID}/tables")]
        public GenericResponse<IEnumerable<SQLInfoTablesVM>> GetTables(int databaseID)
        {
            var tablesVM = _sqlinfo.GetTables(databaseID);
            return new GenericResponse<IEnumerable<SQLInfoTablesVM>>(tablesVM.Select(t => t.ToVMtables()));
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            var script = _sqlinfo.MergeScript(databaseID, tableID);
            return new GenericResponse<string>(script);
        }
    }
}
