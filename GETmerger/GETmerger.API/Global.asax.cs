using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GETmerger.DI;
using GETmerger.DI.Modules;
using log4net;

namespace GETmerger.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger("LOGGER");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            //DI
            var currentAssembly = Assembly.GetExecutingAssembly();
            var config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            var connectionString = ConfigurationManager.ConnectionStrings["MergerContext"].ConnectionString;
            Autofacconfig.ConfigureContainer(config, currentAssembly, connectionString);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log.Info("++++++++++++++++++++++++++++");
            log.Info(@"Application started");
            log.Info("++++++++++++++++++++++++++++");
        }
    }
}
