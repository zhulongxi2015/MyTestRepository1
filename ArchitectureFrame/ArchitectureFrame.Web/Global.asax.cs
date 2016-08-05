using ArchitectureFrame.DTO.AutoMapper;
using ArchitectureFrame.Infrastructure.Extensions;
using ArchitectureFrame.Web.Agency;
using Spring.Context.Support;
using Spring.Web.Mvc;
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
    public class MvcApplication : SpringMvcApplication //System.Web.HttpApplication
    {
        
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(MvcApplication));
        //protected void Application_Start()
        //{

        //    log4net.Config.XmlConfigurator.Configure();
        //    //注册SpringControllerFactory类。SpringMvcApplication类中已经实现了注册SpringControllerFactory类
        //    //ControllerBuilder.Current.SetControllerFactory(typeof(SpringControllerFacotry));
        //    //AreaRegistration.RegisterAllAreas();//注册区域路由 SpringMvcApplication已经调用了注册区域路由
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    //RouteConfig.RegisterRoutes(RouteTable.Routes);//注册RouteConfig中的路由
        //    //this.RegisterRoutes(RouteTable.Routes);//注册自定义路由
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);

        //    //注册Mapper profile 
        //    MapperConfiguration.Configure();
        //}

        protected override void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            //注册SpringControllerFactory类。SpringMvcApplication类中已经实现了注册SpringControllerFactory类
            //ControllerBuilder.Current.SetControllerFactory(typeof(SpringControllerFacotry));
            //AreaRegistration.RegisterAllAreas();//注册区域路由 SpringMvcApplication已经调用了注册区域路由
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);//注册RouteConfig中的路由
            //this.RegisterRoutes(RouteTable.Routes);//注册自定义路由
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //注册Mapper profile 
            MapperConfiguration.Configure();
            base.Application_Start(sender, e);
        }
        protected override void RegisterRoutes(RouteCollection routes)//重写spring.net注册路由
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var nameSpaces = new[] { "ArchitectureFrame.Web.Public.Controllers.*" };
            var defaults = new { controller = "Home", action = "Index", id = UrlParameter.Optional };


            routes.Map("", defaults);
            routes.Map("{controller}/{action}/{id}", defaults, nameSpaces);
        }
        ///// <summary>
        ///// 注册自定义路由
        ///// </summary>
        ///// <param name="routes"></param>
        //private void RegisterRoutes(RouteCollection routes)
        //{
        //    var nameSpaces = new[] { "ArchitectureFrame.Web.Public.Controllers.*" };
        //    var defaults = new { controller = "Home", action = "Index", id = UrlParameter.Optional };


        //    routes.Map("", defaults);
        //    routes.Map("{controller}/{action}/{id}", defaults, nameSpaces);

        //    //routes.Map("Category/Index/{id}", null, nameSpaces);
        //}


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

#region //SpringMVCApplication源码 　Spring.NET 1.3.1的程序集Spring.Web.Mvc提供对ASP.NET MVC程序的整合
//public abstract class SpringMvcApplication : HttpApplication
//{
//    /// <summary>
//    /// Handles the Start event of the Application control.
//    /// </summary>
//    /// <param name="sender">The source of the event.</param>
//    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
//    protected virtual void Application_Start(object sender, EventArgs e)
//    {
//        RegisterAreas();
//        RegisterRoutes(RouteTable.Routes);
//    }

//    /// <summary>
//    /// Configures the <see cref="Spring.Context.IApplicationContext"/> instance.
//    /// </summary>
//    /// <remarks>
//    /// You must override this method in a derived class to control the manner in which the
//    /// <see cref="Spring.Context.IApplicationContext"/> is configured.
//    /// </remarks>        
//    protected virtual void ConfigureApplicationContext()
//    {

//    }


//    /// <summary>
//    /// Executes custom initialization code after all event handler modules have been added.
//    /// </summary>
//    public override void Init()
//    {
//        base.Init();

//        //the Spring HTTP Module won't have built the context for us until now so we have to delay until the init
//        ConfigureApplicationContext();
//        RegisterSpringControllerFactory();
//    }

//    /// <summary>
//    /// Registers the areas.
//    /// </summary>
//    /// <remarks>
//    /// Override this method in a derived class to modify the registered areas as neeeded.
//    /// </remarks>
//    protected virtual void RegisterAreas()
//    {
//        AreaRegistration.RegisterAllAreas();
//    }

//    /// <summary>
//    /// Registers the routes.
//    /// </summary>
//    /// <remarks>
//    /// Override this method in a derived class to modify the registered routes as neeeded.
//    /// </remarks>
//    protected virtual void RegisterRoutes(RouteCollection routes)
//    {
//        // This IgnoreRoute call is provided to avoid the trouble of CASSINI passing all req's thru
//        // ASP.NET (and thus the controller pipeline) during debugging
//        // see http://stackoverflow.com/questions/487230/serving-favicon-ico-in-asp-net-mvc and elsewhere for more info
//        routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

//        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//        routes.MapRoute(
//            "Default", // Route name
//            "{controller}/{action}/{id}", // URL with parameters
//            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
//        );

//    }

//    /// <summary>
//    /// Registers the controller factory with the Mvc Framework.
//    /// </summary>
//    protected virtual void RegisterSpringControllerFactory()
//    {
//        ControllerBuilder.Current.SetControllerFactory(typeof(SpringControllerFactory));
//    }

//} 
#endregion

#region Spring.web.MVC中的SpringControllerFactory
//public class SpringControllerFactory : DefaultControllerFactory
//{
//private static IApplicationContext _context;

///// <summary>
///// Gets the application context.
///// </summary>
///// <value>The application context.</value>
//public static IApplicationContext ApplicationContext
//{
//    get
//    {
//        if (_context == null || _context.Name != ApplicationContextName)
//        {
//            if (string.IsNullOrEmpty(ApplicationContextName))
//            {
//                _context = ContextRegistry.GetContext();
//            }
//            else
//            {
//                _context = ContextRegistry.GetContext(ApplicationContextName);
//            }
//        }

//        return _context;
//    }
//}

///// <summary>
///// Gets or sets the name of the application context.
///// </summary>
///// <remarks>
///// Defaults to using the root (default) Application Context.
///// </remarks>
///// <value>The name of the application context.</value>
//public static string ApplicationContextName { get; set; }

///// <summary>
///// Creates the specified controller by using the specified request context.
///// </summary>
///// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
///// <param name="controllerName">The name of the controller.</param>
///// <returns>A reference to the controller.</returns>
///// <exception cref="T:System.ArgumentNullException">The <paramref name="requestContext"/> parameter is null.</exception>
///// <exception cref="T:System.ArgumentException">The <paramref name="controllerName"/> parameter is null or empty.</exception>
//public override IController CreateController(RequestContext requestContext, string controllerName)
//{
//    IController controller;

//    if (ApplicationContext.ContainsObjectDefinition(controllerName))
//    {
//        controller = ApplicationContext.GetObject(controllerName) as IController;
//    }
//    else
//    {
//        controller = base.CreateController(requestContext, controllerName);
//    }

//    AddActionInvokerTo(controller);

//    return controller;
//}

///// <summary>
///// Retrieves the controller instance for the specified request context and controller type.
///// </summary>
///// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
///// <param name="controllerType">The type of the controller.</param>
///// <returns>The controller instance.</returns>
///// <exception cref="T:System.Web.HttpException">
/////     <paramref name="controllerType"/> is null.</exception>
///// <exception cref="T:System.ArgumentException">
/////     <paramref name="controllerType"/> cannot be assigned.</exception>
///// <exception cref="T:System.InvalidOperationException">An instance of <paramref name="controllerType"/> cannot be created.</exception>
//protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
//{
//    IController controller = null;

//    if (controllerType != null)
//    {
//        var controllers = ApplicationContext.GetObjectsOfType(controllerType);
//        if (controllers.Count > 0)
//        {
//            controller = (IController)controllers.Cast<DictionaryEntry>().First<DictionaryEntry>().Value;
//        }
//    }
//    else
//    {
//        //pass to base class for remainder of handling if can't find it in the context
//        controller = base.GetControllerInstance(requestContext, controllerType);
//    }

//    AddActionInvokerTo(controller);

//    return controller;
//}

///// <summary>
///// Adds the action invoker to the controller instance.
///// </summary>
///// <param name="controller">The controller.</param>
//protected virtual void AddActionInvokerTo(IController controller)
//{
//    if (controller == null)
//        return;

//    if (typeof(Controller).IsAssignableFrom(controller.GetType()))
//    {
//        ((Controller)controller).ActionInvoker = new SpringActionInvoker(ApplicationContext);
//    }
//}

//} 
#endregion