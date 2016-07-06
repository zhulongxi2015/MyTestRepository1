using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Mappings
{
  public  class ArticleMapping: MappingBase<Article>, IMapping
    {
        public ArticleMapping()
        {
            this.Property(x => x.Code).IsRequired().HasMaxLength(200);
            this.Property(x => x.CategoryCode).HasMaxLength(100);
        }
    }
}
