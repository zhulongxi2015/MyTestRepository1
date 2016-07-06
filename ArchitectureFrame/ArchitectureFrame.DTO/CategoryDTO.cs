using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DTO
{
   public class CategoryDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string English { get; set; }
        public short IsPage { get; set; }


        public string iconCls { get; set; }
        public bool leaf { get; set; }
        public bool expanded { get; set; }
        public IList<object> children { get; set; }
    }
}
