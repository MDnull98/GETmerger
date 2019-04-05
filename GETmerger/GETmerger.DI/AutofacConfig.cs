using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using GETmerger.DI.Modules;

namespace GETmerger.DI
{
    public class Autofacconfig
    {
        public static void ConfigureContainer(HttpConfiguration config, Assembly assembly, string connectionString)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacDAL(connectionString));
            builder.RegisterModule(new AutofacBLL(connectionString));
            builder.RegisterModule(new AutofacWebApi(config, assembly));

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
        }
    }
}
