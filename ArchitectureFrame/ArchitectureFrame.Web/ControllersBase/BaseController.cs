using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.ControllersBase
{
    public class BaseController : Controller
    {
        protected static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");
    }
}