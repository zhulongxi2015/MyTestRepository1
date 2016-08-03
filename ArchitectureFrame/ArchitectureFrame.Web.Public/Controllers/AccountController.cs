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

namespace ArchitectureFrame.Web.Public.Controllers
{
    public class AccountController : PublicControllerBase
    {

        public IUserService UserService { get; set; }
        public IRoleService RoleService { get; set; }

        public ActionResult Login()
        {
            return AreaView("account/login.cshtml", new LayoutViewModel());
        }
        [HttpPost]
        public ActionResult Login(string user_name, string password)
        {
            return AreaView("home/index.cshtml", new LayoutViewModel());
        }

        public StandardJsonResult Register(FormCollection form)
        {
            return base.Try(() => {
                Model.User user = new Model.User(form["user_name"], CryptToService.Md5HashEncrypt(form["password"]))
                {
                    Gender = (Gender)Enum.Parse(typeof(Gender), form["gender"])
                };
                UserService.Register(user);
               var currentUser = UserService.GetItems(u => u.UserName.ToLower() == form["user_name"]).FirstOrDefault();
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
