using Autofac;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;
using GETmerger.DAL.EFContexts;
using GETmerger.DAL.QueryRepositories;
using GETmerger.DAL.Repositories;
using Module = Autofac.Module;

namespace GETmerger.DI.Modules
{
    public class AutofacDAL: Module
    {
        private readonly string _connectionString;

        public AutofacDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<SqlInfoQueryRepository>()
                .As(typeof(IDBQueryRepository))
                .WithParameter("dbconnection", _connectionString);

            moduleBuilder.RegisterType<SqlInfoQueryRepository>()
                .As(typeof(ITableQueryRepository))
                .WithParameter("dbconnection", _connectionString);

            moduleBuilder.RegisterType<ScriptQueryRepository>()
                .As(typeof(IScriptQueryRepository))
                .WithParameter("dbconnection", _connectionString);

            moduleBuilder.RegisterType<HistoryRepository>()
                 .As(typeof(IHistoryRepository));

            moduleBuilder.RegisterType<HistoryQueryRepository>()
                .As(typeof(IHistoryQueryRepository));

            moduleBuilder.RegisterType<MergerContext>().AsSelf();
        }
    }
}
