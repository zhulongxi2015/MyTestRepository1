using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Core
{
    public class KnownException : Exception
    {
        public KnownException(string message) : 
            base(string.IsNullOrEmpty(message) ? "Unknown Exception" : message)
        {

        }
    }
}
