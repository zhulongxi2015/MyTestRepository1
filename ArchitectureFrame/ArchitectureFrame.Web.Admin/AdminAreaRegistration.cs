using ArchitectureFrame.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Admin
{
   public class AdminAreaRegistration:AreaRegistration
    {
        public const string Name = "Admin";

        public override string AreaName => Name;

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var nameSpaces = new[] { "ArchitectureFrame.Web.Admin.Controllers.*" };
            context.Map("admin", "Account", "Index", nameSpaces);
            context.Map("admin/{controller}/{action}/{id}", new { controller = "account", action = "index", id = UrlParameter.Optional }, nameSpaces);
        }


    }
}
