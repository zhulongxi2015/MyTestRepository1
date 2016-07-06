using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Utilities
{
    public static class IOHelper
    {
        public static void CreateDirectoryIfNotExists(string directory)
        {
            lock (string.Intern(directory))
            {
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
        }
    }
}
