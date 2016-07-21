using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Mappings
{
   public class UserRoleMapping: MappingBase<UserRole>, IMapping
    {
        public UserRoleMapping()
        {
            this.HasRequired(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).WillCascadeOnDelete(false);
        }
    }
}
