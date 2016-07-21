using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
   public class Role:ModelBase
    {
        public string RoleName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public class Names
        {
            public const string SuperAdmin = "SuperAdmin";
            public const string SaleAgent = "SaleAgent";
            public const string Dealer = "Dealer";
            public const string Customer = "Customer";
        }
    }
}
