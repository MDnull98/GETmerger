using System.Collections.Generic;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface ISQLInfoService
    {
        List<DBQueryInputModel> GetDataBasesList();
        List<TableQueryInputModel> GetTables(int databaseId);
        string GetMergeScript(int databaseID, int tableID);
    }
}
