using System.Collections.Generic;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface IHistoryService
    {
        IEnumerable<HistoryModel> GetHistory();
        HistoryModel Get(int? id);

        void Delete(int id);
    }
}
