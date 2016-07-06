using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Mvc
{
    public interface IStandardResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        void Succeed();
        void Fail();
        void Succeed(string message);
        void Fail(string message);
    }

    public interface IStandardResult<T> : IStandardResult
    {
        T Value { get; set; }
    }
}
