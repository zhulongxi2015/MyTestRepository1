using ArchitectureFrame.Infrastructure.Core;
using ArchitectureFrame.Infrastructure.Mvc;
using ArchitectureFrame.Infrastructure.Security;
using ArchitectureFrame.IService;
using ArchitectureFrame.Model.Enums;
using ArchitectureFrame.Web.Agency.ViewModels;
using ArchitectureFrame.Web.Public.ControllerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace ArchitectureFrame.Web.Public.Controllers
{
    public class AccountController : PublicControllerBase
    {

        public IUserService UserService { get; set; }
        public IRoleService RoleService { get; set; }

        public ActionResult Login(string returnUrl)
        {
            var model = new LayoutViewModel<string>();
            model.Model = returnUrl;
            return AreaView("Account/login.cshtml", model);
        }
        [HttpPost]
        public StandardJsonResult Login(string user_name, string password,string chk_remember)
        {
            return base.Try(() => {
                UserService.Login(user_name, password);
                var currentUser = UserService.GetItems(u => u.UserName.ToLower() == user_name).FirstOrDefault();
                string[] userRoles = RoleService.GetUserRoleNames(currentUser.Id);
                base.LoginUser(currentUser, userRoles);
            });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            GetSession().Logout();
            Session.Abandon();
            return Redirect("/");
        }
        public StandardJsonResult Register(FormCollection form)
        {
            return base.Try(() => {
                string name = form["user_name"];
                string password = form["password"];
                string gender = form["gender"];
                Model.User user = new Model.User(name, CryptToService.Md5HashEncrypt(password))
                {
                    Gender = (Gender)Enum.Parse(typeof(Gender), gender)
                };
                UserService.Register(user);
               var currentUser = UserService.GetItems(u => u.UserName.ToLower() == name).FirstOrDefault();
                string[] userRoles = RoleService.GetUserRoleNames(currentUser.Id);
                base.LoginUser(currentUser, userRoles);
            });
        }
        public StandardJsonResult CheckUserName(string userName)
        {
            return base.Try(() =>
            {
                var query = UserService.GetItems(u => u.UserName == userName);
                if (query != null && query.Count() > 0)
                {
                    //Response.AddHeader("Cache-Control", "no-cache");
                    throw new KnownException("The user name already exists!");
                }
            });
        }
    }
}
