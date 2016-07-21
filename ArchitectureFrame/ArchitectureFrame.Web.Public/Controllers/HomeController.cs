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
   public class HomeController: PublicControllerBase
    {
        public ActionResult Index()
        {
            // return View("~/areas/Public/Views/home/index.cshtml");
            return AreaView("home/index.cshtml", new LayoutViewModel());
        }

    }
}
