using ArchitectureFrame.Infrastructure.Core;
using ArchitectureFrame.Infrastructure.Extensions;
using ArchitectureFrame.Infrastructure.Log;
using ArchitectureFrame.Infrastructure.Mvc;
using ArchitectureFrame.Model;
using ArchitectureFrame.Web.Agency.Extensions;
using ArchitectureFrame.Web.Agency.Security;
using ArchitectureFrame.Web.Agency.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Agency.Controllers
{
    public abstract class ArchitectureFrameControllerBase : Controller
    {
        protected abstract string AreaName { get; }

        private Type _actionResultType;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.ActionDescriptor as ReflectedActionDescriptor;
            if (action != null)
            {
                _actionResultType = action.MethodInfo.ReturnType;
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.logger.Error("ArchitectureFrameControllerBase.OnException",filterContext.Exception);
            if (_actionResultType != null)
            {
                base.OnException(filterContext);
                return;
            }
            string error;
            if (filterContext.Exception is KnownException)
            {
                error = filterContext.Exception.Message;
            }
            else
            {
                error = filterContext.Exception.GetAllMessages();
            }
            if (_actionResultType == typeof(StandardJsonResult) || (_actionResultType == typeof(StandardJsonResult<>)))
            {
                var result = new StandardJsonResult();
                result.Fail(error);
                filterContext.Result = result;
            }
            else if (_actionResultType == typeof(PartialViewResult))
            {
                filterContext.Result = new ContentResult() { Content = error };
            }
            else
            {
                filterContext.Result = Error(error);
            }
            filterContext.ExceptionHandled = true;
        }
        protected ActionResult Error(string message)
        {
            var model = new LayoutViewModel();
            model.Error = message;
            return View("~/areas/public/views/shared/_error.cshtml", model);
        }

        protected ViewResult AreaView(string path, object model = null)
        {
            return View("~/areas/" + AreaName + "/views/" + path, model);
        }

        protected PartialViewResult AreaPartialView(string path, object model = null)
        {
            return PartialView("~/areas/" + AreaName + "/views/" + path, model);
        }

        protected virtual ActionResult Message(string message)
        {
            var model = new LayoutViewModel<string>();
            model.Model = message;
            return View("~/areas/public/views/shared/message.cshtml", model);
        }

        protected MvcSession GetSession()
        {
            return System.Web.HttpContext.Current.Session.GetMvcSession();
        }

        public StandardJsonResult Try(Action action)
        {
            var result = new StandardJsonResult();
            result.Try(action);
            return result;
        }

        public StandardJsonResult<T> Try<T>(Func<T> action)
        {
            var result = new StandardJsonResult<T>();
            result.Try(() =>
            {
                result.Value = action();
            });
            return result;
        }

        public ActionResult TryView(Func<ActionResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                if (ex is KnownException)
                {
                    return Message(ex.Message);
                }
                return Message(ex.GetAllMessages());
            }
        }

        //protected Guid GetUserId()
        //{
        //    return Request.GetUserId();
        //}

        protected void LoginUser(User user,string[] userRoles)
        {
            Response.SetAuthorCookie(user.UserName, userRoles);
            GetSession().Login(user.Id);
        }
    }
}
