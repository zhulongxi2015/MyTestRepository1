using ArchitectureFrame.IService;
using ArchitectureFrame.Web.Admin.ControllerBase;
using ArchitectureFrame.Web.Public.ControllerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Admin.Controllers
{
    public class AccountController: PublicControllerBase
    {
        public ICategoryService CategoryService { get; set; }
        public ActionResult Index()
        {
            var test = this.CategoryService.GetAll();
            return View("~/areas/Admin/Views/Account/index.cshtml");
        }
    }
}
