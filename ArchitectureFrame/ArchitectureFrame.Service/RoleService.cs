using ArchitectureFrame.IDAL;
using ArchitectureFrame.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Service
{
    public class RoleService : IRoleService
    {
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(UserService));
        public IRoleDAL RoleDAL { get; set; }
        public string[] GetUserRoleNames(int userId)
        {
            return RoleDAL.GetUserRoleNames(userId);
        }
    }
}
