using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GETmerger.API.App_Start;
using GETmerger.DI;
using GETmerger.DI.Modules;

namespace GETmerger.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DI
            //AutofacAPIconfig.ConfigureContainer();
            var currentAssembly = Assembly.GetExecutingAssembly();
            var config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            var connectionString = ConfigurationManager.ConnectionStrings["MergerContext"].ConnectionString;
            Autofacconfig.ConfigureContainer(config, currentAssembly, connectionString);
        }
    }
}
