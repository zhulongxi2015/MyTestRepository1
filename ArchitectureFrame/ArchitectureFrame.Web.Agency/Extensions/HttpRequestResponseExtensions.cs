using ArchitectureFrame.Infrastructure.Extensions;
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

        public static string GetUserHostAddress(this HttpRequest request)
        {
            //直接获取客户端Ip地址（无视代理Ip）
            string userHostAddress = request.UserHostAddress;
            //如果客户端使用了代理服务器，则利用HTTP_X_FORWARDED_FOR找到客户端IP地址,由于通过代理服务器的HTTP_X_FORWARDED_FOR获取的ip地址是直接从http报头的"X_FORWARDED_FOR"属性取得，所以这里就提供给恶意破坏者一个办法:可以伪造IP地址!! 故这里忽视代理服务器地址
            // string userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = request.ServerVariables["REMOTE_ADDR"];
            }
            if (!string.IsNullOrEmpty(userHostAddress) && userHostAddress.IsIP())
            {
                return userHostAddress;
            }
            return "172.0.0.1";
        }
    }
}
