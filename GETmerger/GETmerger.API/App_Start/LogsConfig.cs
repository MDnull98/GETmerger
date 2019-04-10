using System.IO;
using log4net;
using System.Web;

namespace GETmerger.API.App_Start
{
    public class LogsConfig: System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger("LOGGER");

        public static void Configure()
        {
            var param = Server.MapPath("~/Web.config");
            var file = new FileInfo(param);
            log4net.Config.XmlConfigurator.Configure(file);
        }
    }
}