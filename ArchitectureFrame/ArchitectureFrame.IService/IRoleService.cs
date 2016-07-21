using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IService
{
    public interface IRoleService
    {
        string[] GetUserRoleNames(int userId);
    }
}
