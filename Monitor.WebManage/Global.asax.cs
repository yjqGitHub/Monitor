using Monitor.WebManage.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Monitor.WebManage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootStrapper.Install();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            BootStrapper.UnInstall();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();
            //LogUtil.Error(ex, memberName: "Application_Error");
        }
    }
}
