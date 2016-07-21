using ArchitectureFrame.Web.Agency.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace ArchitectureFrame.Web.Agency.Extensions
{
   public static class HttpRequestResponseExtensions
    {
        public static int GetUserIdfromSession(this HttpRequestBase request)
        {
            if (request.IsAuthenticated)
            {
                return HttpContext.Current.Session.GetMvcSession().User.Id;
            }
            return 0;
        }

        public static int GetUserIdfromSession(this HttpRequest request)
        {
            return request.RequestContext.HttpContext.Request.GetUserIdfromSession();
        }

        public static void SetAuthorCookie(this HttpResponseBase response,string userName,string[] userRoles)
        {
            var expire = DateTime.Now.AddDays(1);
            var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expire, true, string.Join(",",userRoles));

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Value = FormsAuthentication.Encrypt(ticket);
            cookie.Expires = expire;
            response.Cookies.Add(cookie);

            var guestCookie = new HttpCookie("GUESTID", Guid.Empty.ToString());
            guestCookie.Expires = DateTime.Now.AddYears(-1);
            response.Cookies.Add(guestCookie);

        }

        public static bool IsAjax(this HttpRequest request)
        {
            return request["ajax"] == "true";
        }

        public static void ToExcel(this HttpResponseBase response,string fileName)
        {
            response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            response.ContentType = "application/ms-excel";
        }
    }
}
