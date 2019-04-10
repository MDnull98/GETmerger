namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IScriptRepository
    {
        string GetMergeScript(int databaseID, int tableID);
    }
}
