using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Extensions
{
   public static class AssemblyExtensions
    {
        /// <summary>
        /// 获取该程序集的所有直接派生类，且在同一命名空间下的类
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="baseType"></param>
        /// <returns></returns>
        public static List<Type> GetInheritedTypes(this Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(x => x.BaseType != null && x.BaseType.GenericEq(baseType)).ToList();
        }
    }
}
