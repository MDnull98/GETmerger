using System.Web.Mvc;
using GETmerger.API.Logger;

namespace GETmerger.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingFilter());
        }
    }
}
