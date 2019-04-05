using System.Text;
using System.Web.Mvc;

namespace GETmerger.API.Logger
{
    public class LoggingFilter : ActionFilterAttribute
    {
        #region Logging

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                var message = new StringBuilder();
                message.Append(string.Format("Executing controller {0}, action {1}.",
                    filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    filterContext.ActionDescriptor.ActionName));

                var k = filterContext.ActionParameters.Values.ToString();
                message.Append(string.Format("Method get parameters :{0}",k));

                log.Info(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
                var message = new StringBuilder();
                var k = filterContext.ActionDescriptor.GetParameters().ToString();
                message.Append(string.Format("Output : {0}", k));
                log.Info(message);
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