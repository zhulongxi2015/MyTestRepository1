using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.ModelExtensions
{
   public static class ModelBaseExtensions
    {
        public static T Get<T>(this IQueryable<T> query, int id) where T : ModelBase
        {
            return query.FirstOrDefault(x=>x.Id==id);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, IEnumerable<int> ids)where T:ModelBase
        {
            return query.Where(x => ids.Contains(x.Id));
        }
    }
}
