using System.Collections.Generic;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface IHistoryService
    {
        List<HistoryOutputModel> GetHistory();

        void Delete(int id);
    }
}
