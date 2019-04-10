using System.Configuration;
using System.Reflection;
using System.Web.Http;
using GETmerger.DI;

namespace GETmerger.API
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            //DI
            var currentAssembly = Assembly.GetExecutingAssembly();
            var config = GlobalConfiguration.Configuration;
            var connectionString = ConfigurationManager.ConnectionStrings["MergerContext"].ConnectionString;

            Autofacconfig.ConfigureContainer(config, currentAssembly, connectionString);
        }
    }
}
