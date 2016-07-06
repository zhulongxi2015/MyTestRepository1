using ArchitectureFrame.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureFrame.DTO;
using ArchitectureFrame.Model;
using ArchitectureFrame.IDAL;

namespace ArchitectureFrame.Service
{
    public class ArticleService : IArticleService
    {
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ArticleService));
        public IArticleDAL ArticleDAL { get; set; }//调用数据访问层对象：通过spring.net来注入
        public bool Add(Article model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ArticleDTO dto)
        {
            throw new NotImplementedException();
        }

        public int DeleteByKeys(IList<string> keys)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Article> GetPageList(ISQLPaging paging)
        {
            throw new NotImplementedException();
        }

        public bool Update(ArticleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
