using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using GETmerger.Core.QueryRepositories;
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
            moduleBuilder.RegisterType<SQLInfoRepository>()
                .As(typeof(IDBQueryRepository))
                .WithParameter("dbconnection", _connectionString);

            moduleBuilder.RegisterType<SQLInfoRepository>()
                .As(typeof(ITableQueryRepository))
                .WithParameter("dbconnection", _connectionString);

            //moduleBuilder.RegisterType<SQLInfoRepository>()
            //    .As(typeof(IScriptRepository))
            //    .WithParameter("dbconnection", _connectionString);

            moduleBuilder.RegisterType<HistoryRepository>()
                 .As(typeof(IHistoryRepository))
                .WithParameter("MergerContext", new MergerContext());
        }
    }
}
