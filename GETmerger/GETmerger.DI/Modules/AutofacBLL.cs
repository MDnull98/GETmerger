using Autofac;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Services;

namespace GETmerger.DI.Modules
{
    public class AutofacBLL:Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<SQLInfoService>().As<ISQLInfoService>();
        }
    }
}