using ArchitectureFrame.IDAL;
using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.DAL
{
   public class ArticleDAL:Repository<Article>,IArticleDAL
    {
        public ArticleDAL(ArchitectureFrameEntities dbContext) : base(dbContext)
        {

        }
        //todo: 实现各个实体自己特殊的方法
    }
}
