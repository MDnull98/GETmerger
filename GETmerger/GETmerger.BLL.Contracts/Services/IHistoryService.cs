using System.Collections.Generic;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface IHistoryService
    {//historyVM
        IEnumerable<HistoryOutputModel> GetHistory();

        void Delete(int id);
    }
}
