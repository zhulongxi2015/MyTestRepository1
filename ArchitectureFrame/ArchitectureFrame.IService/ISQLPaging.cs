using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IService
{
  public interface ISQLPaging
    {
        int PageIndex { get; }
        int PageSize { get; }
        int RecordCount { get; set; }
        string QuerySQL { get; }
    }
}
