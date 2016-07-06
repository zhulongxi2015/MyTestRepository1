using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Extensions
{
    public static class DecimalExtentions
    {
        public static string ToText(this decimal value)
        {
            return value.ToString("g0");
        }
    }
}
