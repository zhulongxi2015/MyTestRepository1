using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IDAL
{
   public interface IRoleDAL:IRepository<Role>
    {
        string[] GetUserRoleNames(int userId);
    }
}
