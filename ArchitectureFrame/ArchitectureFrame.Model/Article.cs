using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
   public partial class Article
    {
        [Key]
        [Column(Order =0)]
        public int ArticleID { get; set; }
        
        [Key]
        [Column(Order =1)]
        public int CategoryID { get; set; }
        public string Code { get; set; }
        public string SourceCode { get; set; }
        public string Title { get; set; }
        public string CategoryCode { get; set; }
        public short Sort { get; set; }
        public string Origin { get; set; }
        public System.DateTime AddTime { get; set; }

        public virtual Category Category { get; set; }
    }
}
