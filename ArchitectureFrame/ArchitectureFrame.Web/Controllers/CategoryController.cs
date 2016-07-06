using ArchitectureFrame.IService;
using ArchitectureFrame.Web.ControllersBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public ICategoryService CategoryService { get; set; }

        // GET: Category
        public ActionResult Index()
        {
            var categories = CategoryService.GetAll();
            return View();
        }
    }
}