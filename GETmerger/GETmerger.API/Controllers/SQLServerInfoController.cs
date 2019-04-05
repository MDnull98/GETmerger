using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GETmerger.API.Mapper;
using GETmerger.API.ViewModels;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;

namespace GETmerger.API.Controllers
{
    public class SQLServerInfoController : ApiController
    {
        // 1 GetDatabases()
        // 2 GetTables(int databaseID)
        // 3 GetMergeScript(int databaseID, int tableID)
        private ISQLInfoService _sqlInfoService;

        public SQLServerInfoController(ISQLInfoService sqlInfoService)
        {
            _sqlInfoService = sqlInfoService;
        }

        [Route("api/databases")]
        public GenericResponse<IEnumerable<DBQueryInputModel>> GetDatabases()
        {
            var db = _sqlInfoService.GetDataBasesList();

            return new GenericResponse<IEnumerable<DBQueryInputModel>>(db.Select(x => x.ToVMdatabases()));
        }

        [Route("api/databases/{databaseID}/tables")]
        public GenericResponse<IEnumerable<TableQueryInputModel>> GetTables(int databaseID)
        {
            var tablesVM = _sqlInfoService.GetTables(databaseID);

            return new GenericResponse<IEnumerable<TableQueryInputModel>>(tablesVM.Select(t => t.ToVMtables()));
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            var script = _sqlInfoService.MergeScript(databaseID, tableID);

            return new GenericResponse<string>(script);
        }
    }
}
