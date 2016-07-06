using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Mappings
{
    public interface IMapping
    {
        void RegistTo(ConfigurationRegistrar configurationRegistarar);
    }
}
