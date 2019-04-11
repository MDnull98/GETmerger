using System.Web.Http;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;

namespace GETmerger.API.Controllers
{
    public class MergeController : ApiController
    {
        private readonly IMergeService _mergeService;

        public MergeController(IMergeService mergeService)
        {
            _mergeService = mergeService;
        }

        [Route("api/databases/{databaseID}/tables/{tableID}/merge-script")]
        public GenericResponse<string> GetMergeScript(int databaseID, int tableID)
        {
            var script = _mergeService.GetMergeScript(databaseID, tableID);

            return new GenericResponse<string>(script);
        }
    }
}
