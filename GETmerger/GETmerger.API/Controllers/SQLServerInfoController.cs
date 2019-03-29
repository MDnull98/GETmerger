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
        // 2 GetTables(string databaseName)
        // 3 GetMergeScript(string databaseName, string tableName)
        private ISQLInfoService _sqlinfo;

        public SQLServerInfoController(ISQLInfoService sqlinfo)
        {
            _sqlinfo = sqlinfo;
        }
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

        // GET api/databases
        [HttpGet]
        public IEnumerable<SQLInfoViewModel> GetDatabases1()
        {
            var db = _sqlinfo.GetDataBasesList();
            return db.Select(x => x.ToVMdatabases());
        }

        // GET api/tables
        [HttpGet]
        public IEnumerable<SQLInfoViewModel> GetTables1(int dbid)
        {
            var tablesVM = _sqlinfo.GetTables(dbid);
            return tablesVM.Select(y => y.ToVMtables());
        }
    }
}
