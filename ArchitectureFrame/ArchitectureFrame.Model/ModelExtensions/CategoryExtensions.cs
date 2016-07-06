using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.ModelExtensions
{
   public static class CategoryExtensions
    {
        public static IQueryable<Category> WhereByName(this IQueryable<Category> query, string code)
        {
            var query2 = from a in query
                         from b in a.Articles
                         where b.Category.Code == code
                         select a;
            return query2.Distinct();
        }
    }
}
