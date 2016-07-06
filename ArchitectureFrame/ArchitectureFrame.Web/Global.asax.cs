using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ArchitectureFrame.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(MvcApplication));
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            //WebApplicationContext ctx = ContextRegistry.GetContext() as WebApplicationContext;

            //注册SpringControllerFactory类。
            ControllerBuilder.Current.SetControllerFactory(typeof(ControllersBase.SpringControllerFacotry));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("Logger");

            if (Server.GetLastError() != null)
            {
                Exception ex = Server.GetLastError().GetBaseException();
                StringBuilder sb = new StringBuilder();
                sb.Append(ex.Message);
                sb.Append("\r\nSOURCE: " + ex.Source);
                sb.Append("\r\nFORM: " + Request.Form.ToString());
                sb.Append("\r\nQUERYSTRING: " + Request.QueryString.ToString());
                sb.Append("\r\n引发当前异常的原因: " + ex.TargetSite);
                sb.Append("\r\n堆栈跟踪: " + ex.StackTrace);
                logger.Error(sb.ToString());
                Server.ClearError();
            }
        }
    }
}
