using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IScriptRepository
    {
        ScriptModel GetScript(int databaseID, int tableID);
    }
}
