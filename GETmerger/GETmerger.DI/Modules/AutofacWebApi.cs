using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace GETmerger.DI.Modules
{
    public class AutofacWebApi : Module
    {
        private readonly Assembly _assembly;
        private readonly HttpConfiguration _config;

        public AutofacWebApi(HttpConfiguration config, Assembly assembly)
        {
            _assembly = assembly;
            _config = config;
        }

        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterApiControllers(_assembly);
            moduleBuilder.RegisterWebApiFilterProvider(_config);
            moduleBuilder.RegisterWebApiModelBinderProvider();
        }
    }
}
