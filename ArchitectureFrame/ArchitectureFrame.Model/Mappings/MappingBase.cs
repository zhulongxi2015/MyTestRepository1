using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Mappings
{
    public class MappingBase<TEntity> : EntityTypeConfiguration<TEntity>, IMapping where TEntity:ModelBase
    {
        public void RegistTo(ConfigurationRegistrar configurationRegistarar)
        {
            configurationRegistarar.Add(this);
        }
    }
}
