using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Log
{
  public static class Logger
    {
      public static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");
    }
}
