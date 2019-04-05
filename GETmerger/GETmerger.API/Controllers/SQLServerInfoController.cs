using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GETmerger.API.Mapper;
using GETmerger.API.ViewModels;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;
using log4net;

namespace GETmerger.API.Controllers
{
    public class SQLServerInfoController : ApiController
    {
        // 1 GetDatabases()
        // 2 GetTables(int databaseID)
        // 3 GetMergeScript(int databaseID, int tableID)
        private static ILog log = LogManager.GetLogger("LOGGER");
        private ISQLInfoService _sqlinfoService;

        public SQLServerInfoController(ISQLInfoService sqlinfoService)
        {
            _sqlinfoService = sqlinfoService;
        }

        [Route("api/databases")]
        public GenericResponse<IEnumerable<SQLInfoDatabaseVM>> GetDatabases()
        {
            var dbVM = _sqlinfoService.GetDataBasesList();
            return new GenericResponse<IEnumerable<SQLInfoDatabaseVM>>(dbVM.Select(x => x.ToVMdatabases()));
        }

        [Route("api/databases/{databaseID}/tables")]
        public GenericResponse<IEnumerable<SQLInfoTablesVM>> GetTables(int databaseID)
        {
            var tablesVM = _sqlinfoService.GetTables(databaseID);
            return new GenericResponse<IEnumerable<SQLInfoTablesVM>>(tablesVM.Select(t => t.ToVMtables()));
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            string script = _sqlinfoService.GetMergeScript(databaseID, tableID);
            return new GenericResponse<string>(script);
        }
    }
}
