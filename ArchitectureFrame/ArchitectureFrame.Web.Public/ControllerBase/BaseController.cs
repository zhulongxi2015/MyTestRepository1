﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Public.ControllerBase
{
    public class BaseController : Controller
    {
        protected static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");
    }
}
