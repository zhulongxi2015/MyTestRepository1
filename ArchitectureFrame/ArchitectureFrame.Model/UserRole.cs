using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
   public class UserRole:ModelBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
