﻿using System.IO;
using System.Collections;
using System.Web;
using log4net;

namespace GETmerger.API.App_Start
{
    public class LogConfig: HttpApplication
    {
        public static void Configure(HttpApplication app)
        {
            var param = app.Server.MapPath("~/Web.config");
            var file = new FileInfo(param);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}