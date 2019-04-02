using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.BLL.Contracts.Services
{
    public interface ISQLInfoService
    {
        List<DataBaseQueryModel> GetDataBasesList();
        IEnumerable<TableQueryModel> GetTables(int databaseId);
    }
}
