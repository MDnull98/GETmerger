using System.Collections.Generic;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface IHistoryService
    {
        IEnumerable<HistoryInputModel> GetHistory();

        void Delete(int id);
    }
}
