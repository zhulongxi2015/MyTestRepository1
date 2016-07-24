using ArchitectureFrame.Infrastructure.Core;
using ArchitectureFrame.Infrastructure.Mvc;
using ArchitectureFrame.IService;
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
   public class AccountController:PublicControllerBase
    {
       
        public IUserService UserService { get; set; }

        public ActionResult Login()
        {
            return AreaView("account/login.cshtml", new LayoutViewModel());
        }
        [HttpPost]
        public ActionResult Login(string user_name, string password)
        {
            return AreaView("home/index.cshtml", new LayoutViewModel());
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
