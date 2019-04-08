using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GETmerger.API.Mapper;
using GETmerger.API.ViewModels;
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
        public GenericResponse<IEnumerable<HistoryVM>> GetHistory()
        {
            var history = _historyService.GetHistory();
            return new GenericResponse<IEnumerable<HistoryVM>>(history.Select(x=>x.ToVMHistory()));
        }
        [Route("api/history/{id}")]
        public void Delete(int id)
        {
             _historyService.Delete(id);
        }
    }
}
