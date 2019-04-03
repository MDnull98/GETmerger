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

        [System.Web.Http.Route("api/databases")]
        public GenericResponse<IEnumerable<SQLInfoDatabaseVM>> GetDatabases(ActionExecutingContext filterContext)
        {
            var message = new StringBuilder();
            message.Append(string.Format("Executing controller {0}, action {1}",
            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            filterContext.ActionDescriptor.ActionName));
            log.Info(message);
            var db = _sqlinfo.GetDataBasesList();
            log.Info("Output: "+db);
            return new GenericResponse<IEnumerable<SQLInfoDatabaseVM>>(db.Select(x => x.ToVMdatabases()));
        }

        [System.Web.Http.Route("api/databases/{databaseID}/tables")]
        public GenericResponse<IEnumerable<SQLInfoTablesVM>> GetTables(int databaseID, ActionExecutingContext filterContext)
        {
            log.Info("Request for receiving tables in database_id=" + databaseID);
            //log
            var message = new StringBuilder();
            message.Append(string.Format("Executing controller {0}, action {1}",
            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            filterContext.ActionDescriptor.ActionName));
            log.Info(message);
            var db = _sqlinfo.GetDataBasesList();
            log.Info("Output: " + db);
            var tablesVM = _sqlinfo.GetTables(databaseID);
            return new GenericResponse<IEnumerable<SQLInfoTablesVM>>(tablesVM.Select(t => t.ToVMtables()));
        }

        [System.Web.Http.Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            var script = _sqlinfo.MergeScript(databaseID, tableID);
            return new GenericResponse<string>(script);
        }
    }
}
