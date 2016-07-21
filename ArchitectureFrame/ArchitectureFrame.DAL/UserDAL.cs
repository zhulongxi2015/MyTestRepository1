using ArchitectureFrame.IDAL;
using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DAL
{
   public class UserDAL:Repository<User>,IUserDAL
    {
        public UserDAL(ArchitectureFrameEntities dbcontext):base(dbcontext)
        {

        }
    }
}
