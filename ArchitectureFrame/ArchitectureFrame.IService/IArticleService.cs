using ArchitectureFrame.DTO;
using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IService
{
    public interface IArticleService
    {
        //定义跟业务逻辑相关的方法
        IQueryable<Article> GetAll();
        IQueryable<Article> GetPageList(ISQLPaging paging);
        bool Add(Article model);
        bool Update(ArticleDTO dto);
        bool Delete(ArticleDTO dto);
        int DeleteByKeys(IList<string> keys);
    }
}
