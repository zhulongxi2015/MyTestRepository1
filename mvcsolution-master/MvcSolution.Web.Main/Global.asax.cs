using System.Web.Mvc;
using System.Web.Routing;
using MvcSolution.Services;
using System.Web.Security;
using System.Web;
using System.Security.Principal;

namespace MvcSolution.Web.Main
{
    public class MainApplication : MvcApplication
    {
        protected override void OnApplicationStart()
        {
            SettingContext.Instance.Init();
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            var imgns = new[] { "MvcSolution.Web.Controllers.*" };
            routes.Map("img/{size}/default-{name}.{format}", "image", "SystemDefault", imgns);
            routes.Map("img/{size}/t{imageType}t{yearMonth}-{id}.{format}", "image", "index", imgns);
            routes.Map("img/{size}/{parameter}", "image", "index", imgns);

            var ns = new[] { "MvcSolution.Web.Public.Controllers.*" };
            var defaults = new { controller = "Home", action = "Index", id = UrlParameter.Optional };

            routes.Map("", defaults, ns);
            routes.Map("{controler}/{action}/{id}", defaults, ns);

            //FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
            //FormsAuthenticationTicket ticket = id.Ticket;
            //string userData = ticket.UserData;
            //string[] roles = userData.Split(',');
            //HttpContext.Current.User = new GenericPrincipal(id, roles);
        }

        protected override void RegisterIoc()
        {
            Ioc.RegisterInheritedTypes(typeof(ServiceBase).Assembly, typeof(ServiceBase));
        }
    }
}