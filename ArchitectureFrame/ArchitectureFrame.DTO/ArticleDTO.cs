using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DTO
{
   public class ArticleDTO
    {
        public string Code { get; set; }
        public string SourceCode { get; set; }
        public string Title { get; set; }

        public DateTime? AddStartTime { get; set; }
        public DateTime? AddStopTime { get; set; }
    }
}
