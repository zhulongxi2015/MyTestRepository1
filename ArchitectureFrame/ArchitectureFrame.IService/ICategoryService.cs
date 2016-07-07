using ArchitectureFrame.DTO;
using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IService
{
   public interface ICategoryService
    {
        //定义跟业务逻辑相关的方法
        IQueryable<Category> GetAll();
        IQueryable<Category> GetPageList(ISQLPaging paging);
        Category GetById(int id);
        bool Add(CategoryDTO dto);
        bool Update(CategoryDTO dto);
        bool Delete(CategoryDTO dto);
        int DeleteByKeys(IList<string> keys);

    }
}
