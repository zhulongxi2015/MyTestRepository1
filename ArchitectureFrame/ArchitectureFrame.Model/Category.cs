using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
   public partial class Category:ModelBase
    {
        [Key]
        public int CategoryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string English { get; set; }
        public string ParentCode { get; set; }
        public string UploadCode { get; set; }
        public short IsPage { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }
}
