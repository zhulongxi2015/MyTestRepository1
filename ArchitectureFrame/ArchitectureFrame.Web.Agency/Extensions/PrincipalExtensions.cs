using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Web.Agency.Extensions
{
   public static class PrincipalExtensions
    {
        public static bool IsSupperAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(Role.Names.SuperAdmin);
        }
    }
}
