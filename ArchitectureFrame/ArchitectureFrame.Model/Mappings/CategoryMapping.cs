using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Mappings
{
   public class CategoryMapping: EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            this.Property(x => x.Code).IsRequired().HasMaxLength(200);
            this.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
