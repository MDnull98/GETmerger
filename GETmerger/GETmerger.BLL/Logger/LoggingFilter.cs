﻿using System.Reflection;
using System.Text;
using System.Web.Mvc;
using log4net;

namespace GETmerger.API.Logger
{
    public class LoggingFilter : ActionFilterAttribute, IExceptionFilter
    {
        #region Logging

        // public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog log = LogManager.GetLogger("LOGGER");
        #endregion

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                var message = new StringBuilder();
                message.Append(string.Format("Executing controller {0}, action {1}.",
                    filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    filterContext.ActionDescriptor.ActionName));
                log.Info(message);
                var k = filterContext.ActionParameters.Values.ToString();
                log.Info($@"Method get parameters: {k}");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
                var message = new StringBuilder();
                var k = filterContext.ActionDescriptor.GetParameters().ToString();
                message.Append(string.Format("Output : {0}", k));
                log.Info(message);
        }

        public void OnException(ExceptionContext filterContext)
        {
            log.Error($@"Произошла ошибка в {MethodBase.GetCurrentMethod().Name}: ",filterContext.Exception);
        }
    }
}