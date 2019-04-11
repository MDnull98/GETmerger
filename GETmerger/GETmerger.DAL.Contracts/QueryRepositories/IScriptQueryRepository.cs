namespace GETmerger.DAL.Contracts.QueryRepositories
{
    public interface IScriptQueryRepository
    {
        string GetMergeScript(int databaseID, int tableID);
    }
}
