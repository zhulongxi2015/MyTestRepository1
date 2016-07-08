using ArchitectureFrame.IService;
using ArchitectureFrame.Web.Public.ControllerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Public.Controllers
{
    public class CategoryController : PublicControllerBase
    {
        public ICategoryService CategoryService { get; set; }
        
        public ActionResult Index()
        {
            var test = this.CategoryService.GetAll();
            return View("~/areas/Public/Views/Category/index.cshtml");
            //~/areas/Public/Views/Category/index.cshtml
        }
    }
}
