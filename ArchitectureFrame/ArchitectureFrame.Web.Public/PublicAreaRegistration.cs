using ArchitectureFrame.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchitectureFrame.Web.Public
{
   public class PublicAreaRegistration:AreaRegistration
    {
        public const string Name = "Public";

        public override string AreaName => Name;

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var nameSpaces = new[] { "ArchitectureFrame.Web.Public.Controllers.*" };
            context.Map("Login", "Account", "Login", nameSpaces);
            context.Map("Logout", "Account", "Logout", nameSpaces);
            context.Map("main/{controller}/{action}/{id}", new { controller= "main", action="index",id=UrlParameter.Optional}, nameSpaces);
        }
    }
}
