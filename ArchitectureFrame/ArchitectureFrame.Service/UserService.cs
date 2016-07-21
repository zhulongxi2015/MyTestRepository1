using ArchitectureFrame.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureFrame.DTO;
using ArchitectureFrame.Model;
using ArchitectureFrame.IDAL;
using AutoMapper;
using ArchitectureFrame.Infrastructure.Core;
using ArchitectureFrame.Infrastructure.Security;
using System.Web;
using ArchitectureFrame.Infrastructure.Utilities;
using System.Linq.Expressions;

namespace ArchitectureFrame.Service
{
    public class UserService : IUserService
    {
        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(UserService));
        public IUserDAL UserDAL { get; set; }//调用数据访问层对象：通过spring.net来注入
        public IRoleDAL RoleDAL { get; set; }

        public User GetbyId(int id)
        {
            return UserDAL.GetbyId(id);
        }
        public SessionUser GetSessionUser(int id)
        {
            var user = UserDAL.GetbyId(id);
            if (user == null)
            {
                return null;
            }
            SessionUser sessionUser = Mapper.Map<User, SessionUser>(user);
            sessionUser.Roles = RoleDAL.GetUserRoleNames(id);
            return sessionUser;
        }
        public SessionUser GetSessionUser(string userName)
        {
            var user = UserDAL.GetItems(u=>u.UserName==userName).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            SessionUser sessionUser = Mapper.Map<User, SessionUser>(user);
            sessionUser.Roles = RoleDAL.GetUserRoleNames(user.Id);
            return sessionUser;
        }
        public void Login(string userName, string password)
        {
            var users = UserDAL.GetItems(u => u.UserName == userName);
            if (users == null)
            {
                throw new KnownException("The user name doesn't exists!");
            }
            var user = users.First();
            if (CryptToService.Md5HashEncrypt(password) != user.Password)
            {
                throw new KnownException("Incorrect password!");
            }
            user.LastLoginTime = DateTime.Now;
            if (!UserDAL.Update(user))
            {
                logger.Error("Login failed: Update");
                throw new KnownException("Login failed: Update");
            }
        }

        public void Register(string userName, string password)
        {
            var ip = HttpContext.Current.Request.UserHostAddress;
            if (UserDAL.Exists(u => u.UserName == userName))
            {
                throw new KnownException("User already exists");
            }
            var user = new User(userName, CryptToService.Md5HashEncrypt(password));
            if (!UserDAL.Add(user))
            {
                logger.Error("Login failed: Add");
                throw new KnownException("Register failed:　Add");
            }
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetPageList(ISQLPaging paging)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetItems(Expression<Func<User, bool>> predicate)
        {
            return UserDAL.GetItems(predicate);
        }

        public bool Add(User model)
        {
            throw new NotImplementedException();
        }

        public bool Update(User dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User dto)
        {
            throw new NotImplementedException();
        }

        public int DeleteByKeys(IList<string> keys)
        {
            throw new NotImplementedException();
        }
    }
}
