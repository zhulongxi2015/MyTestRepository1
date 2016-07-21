using ArchitectureFrame.IDAL;
using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DAL
{
    public class RoleDAL : Repository<Role>, IRoleDAL
    {
        public RoleDAL(ArchitectureFrameEntities dbcontext) : base(dbcontext)
        {

        }
        public string[] GetUserRoleNames(int userId)
        {
            var query = from a in DbContext.Set<Role>()
                        from b in a.UserRoles
                        where b.UserId == userId
                        select a.RoleName;
            return query.Distinct().ToArray();

        }
    }
}
