using System.Collections.Generic;
using System.Web.Http;
using GETmerger.BLL.Contracts.Models.Input;
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
        private readonly ISQLInfoService _sqlinfoService;

        public SQLServerInfoController(ISQLInfoService sqlinfoService)
        {
            _sqlinfoService = sqlinfoService;
        }

        [Route("api/databases")]
        public GenericResponse<IEnumerable<DBQueryModel>> GetDatabases()
        {
            var dbVM = _sqlinfoService.GetDataBasesList();

            return new GenericResponse<IEnumerable<DBQueryModel>>(dbVM);
        }

        [Route("api/databases/{databaseID}/tables")]
        public GenericResponse<IEnumerable<TableQueryInputModel>> GetTables(int databaseID)
        {
            var tablesVM = _sqlinfoService.GetTables(databaseID);

            return new GenericResponse<IEnumerable<TableQueryInputModel>>(tablesVM);
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            var script = _sqlinfoService.GetMergeScript(databaseID, tableID);

            return new GenericResponse<string>(script);
        }
    }
}
