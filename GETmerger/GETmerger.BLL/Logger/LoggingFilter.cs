﻿using System.Reflection;
using System.Text;
using System.Web.Mvc;
using log4net;

namespace GETmerger.API.Logger
{
    public class LoggingFilter : ActionFilterAttribute, IExceptionFilter 
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = new StringBuilder();
            message.Append($@"Executing method {MethodBase.GetCurrentMethod().Name} include {filterContext.ActionDescriptor.GetParameters()}");

            log.Info(message);

            var k = filterContext.ActionParameters.Values.ToString();
            message.Append($@"Method get parameters :{k}");

            log.Info(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = new StringBuilder();
            var k = filterContext.ActionDescriptor.GetParameters().ToString();
            message.Append(string.Format($@"Output : {k}"));

            log.Info(message);
        }

        public void OnException(ExceptionContext filterContext)
        {
          log.Error("Error in Controller", filterContext.Exception);
        }
    }
}