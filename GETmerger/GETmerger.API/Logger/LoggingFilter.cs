using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GETmerger.API.Logger
{
    public class LoggingFilter : ActionFilterAttribute
    {
        #region Logging

        protected static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (log.IsDebugEnabled)
            {
                var message = new StringBuilder();
                message.Append(string.Format("Executing controller {0}, action {1}",
                    filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    filterContext.ActionDescriptor.ActionName));
                log.Debug(message);
            }
        }

        public void OnException(ExceptionContext filterContext, HandleErrorAttribute hea)
        {
            if (filterContext.Exception != null)
            {
                log.Error("Error in Controller", filterContext.Exception);
            }
            hea.OnException(filterContext);
        }
    }
}