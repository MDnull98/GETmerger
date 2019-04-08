using System.Collections.Generic;
using System.Web.Http;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.Core.Models;

namespace GETmerger.API.Controllers
{
    public class HistoryController : ApiController
    {
        //1 GetHistory()
        //2 DeleteHistoryNote(int id)

        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        [Route("api/history")]
        public GenericResponse<IEnumerable<HistoryOutputModel>> GetHistory()
        {
            var history = _historyService.GetHistory();
            return new GenericResponse<IEnumerable<HistoryOutputModel>>(history);
        }
        [Route("api/history/{id}")]
        public GenericResponse Delete(int id)
        {
             _historyService.Delete(id);
             return new GenericResponse();
        }
    }
}
