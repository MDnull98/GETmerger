using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IScriptRepository
    {
        string GetScript(int databaseID, int tableID);
    }
}
