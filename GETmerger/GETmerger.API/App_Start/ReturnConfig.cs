using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace GETmerger.API.App_Start
{
    public class ReturnConfig
    {
        public static void Configure()
        {
            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}