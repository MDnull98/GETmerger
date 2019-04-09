using Autofac;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Services;

namespace GETmerger.DI.Modules
{
    public class AutofacBLL:Module
    {
        private readonly string _connectionString;

        public AutofacBLL(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<SQLInfoService>()
                .As(typeof(ISQLInfoService));
            moduleBuilder.RegisterType<HistoryService>()
                .As(typeof(IHistoryService));
            // moduleBuilder.RegisterType<SQLInfoService>().As<ISQLInfoService>();
        }
    }
}