using System;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using log4net;

namespace GETmerger.API.Logger
{
    public class MyErrorHandler : HandleErrorAttribute
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public override void OnException(ExceptionContext filterContext)
        {
            log.Error("ERROR - ",filterContext.Exception);
            base.OnException(filterContext);
        }

    }
}