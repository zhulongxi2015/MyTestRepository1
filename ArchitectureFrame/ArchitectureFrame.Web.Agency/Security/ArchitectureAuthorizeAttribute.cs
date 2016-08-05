using ArchitectureFrame.Infrastructure.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Agency.Security
{
    //MVC授权验证过滤器
    public class ArchitectureAuthorizeAttribute : AuthorizeAttribute
    {
        public ArchitectureAuthorizeAttribute()
        {//任何角色都可以访问

        }
        public ArchitectureAuthorizeAttribute(string roles)//只有角色在roles中的用户才能访问
        {
            this.Roles = roles;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)//进行授权验证
        {
            //针对action 上的attribute
            var actionAttributes = filterContext.ActionDescriptor.GetCustomAttributes(true);
            if (actionAttributes.Any(x => x is AllowAnonymousAttribute))//如果action上的attribute有任何一个是AllowAnonymousAttribute（允许匿名用户访问），则不做授权认证
            {
                return;
            }
            var actionAttribute = actionAttributes.FirstOrDefault(x => x is ArchitectureAuthorizeAttribute);
            if (actionAttribute != null)//如果action上第一个attribute是ArchitectureAuthorizeAttribute，则按照ArchitectureAuthorizeAttribute的授权认证方式进行授权认证
            {
                ((ArchitectureAuthorizeAttribute)actionAttribute).Authorize(filterContext);
                return;
            }
            //针对controller上的attribute
            var controllerAttrs = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true);
            if (controllerAttrs.Any(x => x is AllowAnonymousAttribute))
            {
                return;
            }
            var controllerAttr = controllerAttrs.FirstOrDefault(x => x is ArchitectureAuthorizeAttribute);
            if (controllerAttr != null)
            {
                ((ArchitectureAuthorizeAttribute)controllerAttr).Authorize(filterContext);
                return;
            }
            //base.OnAuthorization(filterContext);
            this.Authorize(filterContext);
        }
        public void Authorize(AuthorizationContext filterContext)
        {
            var context = filterContext.RequestContext.HttpContext;
            bool isAuthenticated = context.Request.IsAuthenticated;//是否已经通过身份验证（即登录成功）

            //首先判断当前用户是否拥有访问该资源必须的角色
            if (!string.IsNullOrEmpty(this.Roles))//如果设置了访问该资源必须的角色
            {
                isAuthenticated = isAuthenticated && this.Roles.Split(',').Any(x => context.User.IsInRole(x));//context.User为通过form验证登录的用户
            }
            if (isAuthenticated)//通过身份验证和授权认证
            {
                return;
            }
            //未通过验证或授权
            if (HttpContext.Current.Request["ajax"] == "true")
            {
                filterContext.Result = new StandardJsonResult()
                {
                    Message = context.Request.IsAuthenticated ? "You don't have sufficient permission" : "Please login"
                };
            }
            else
            {
                filterContext.Result = new RedirectResult("/Home?returnUrl=" + HttpContext.Current.Request.RawUrl);
            }
        }
    }
}
