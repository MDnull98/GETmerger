﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GETmerger.DI.Modules;
using Module = Autofac.Module;

namespace GETmerger.API.App_Start
{
    public class AutofacAPIconfig
    {
        public  static void ConfigureContainer(string connectionString)
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
           
            builder.RegisterModule(new AutofacDAL(connectionString));
            builder.RegisterModule(new AutofacBLL());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}