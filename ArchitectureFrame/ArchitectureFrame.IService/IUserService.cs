using ArchitectureFrame.DTO;
using ArchitectureFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.IService
{
    public interface IUserService
    {
        SessionUser GetSessionUser(int id);
        SessionUser GetSessionUser(string userName);
        void Login(string userName, string password);
        User GetbyId(int id);
        void Register(User user);

        //定义跟业务逻辑相关的方法
        IQueryable<User> GetAll();
        IQueryable<User> GetPageList(ISQLPaging paging);
        IQueryable<User> GetItems(Expression<Func<User, bool>> predicate);
        bool Add(User model);
        bool Update(User dto);
        bool Delete(User dto);
        int DeleteByKeys(IList<string> keys);
    }
}
