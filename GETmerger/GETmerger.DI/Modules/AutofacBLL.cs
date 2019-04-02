using System.Web.Mvc;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using GETmerger.BLL.Contracts.Services;
using GETmerger.BLL.Services;
using GETmerger.DAL.Contracts.Repositories;
using GETmerger.DAL.Repositories;

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