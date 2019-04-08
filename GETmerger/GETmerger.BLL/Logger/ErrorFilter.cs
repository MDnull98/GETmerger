using System.IO;
using System.Text;
using System.Web.Mvc;
using log4net;
using System.Reflection;

namespace GETmerger.API.Logger
{
    public class ErrorFilter : IExceptionFilter
    {
        #region Logging

        // public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ILog log = LogManager.GetLogger("LOGGER");
        #endregion

        public void OnException(ExceptionContext filterContext)
        {
            log.Error($@"Method {MethodBase.GetCurrentMethod().Name} вернул ошибку : ",filterContext.Exception);
        }
    }
}