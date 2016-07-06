using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IDAL
{
   public interface IArticleDAL:IRepository<Article>
    {
        //todo: 定义各个实体自己特殊的数据库访问方法
    }
}
