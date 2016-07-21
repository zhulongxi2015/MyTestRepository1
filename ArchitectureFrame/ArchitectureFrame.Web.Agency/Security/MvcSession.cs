using ArchitectureFrame.DTO;
using ArchitectureFrame.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;


namespace ArchitectureFrame.Web.Agency.Security
{
    public class MvcSession
    {
        public IUserService UserService { get; set; }

        private SessionUser _user;

        public SessionUser User
        {
            get { return _user; }
        }
        public bool IsAuthenticated
        {
            get { return HttpContext.Current.Request.IsAuthenticated; }
        }
        public void Logout()
        {
            _user = null;
        }

        public void Login(int userId)
        {
            ReloadAll(userId);
        }

        public void Init()
        {
            if (!IsAuthenticated)
            {
                Logout();
                return;
            }

            ReloadAll(HttpContext.Current.User.Identity.Name);
        }

        private void ReloadAll(string userName)
        {
            _user = UserService.GetSessionUser(userName);
        }
        private void ReloadAll(int userId)
        {
            _user = UserService.GetSessionUser(userId);
        }
    }
    public static class SessionExtensions
    {
        private const string MvcSessionKey = "MvcSession";

        public static MvcSession GetMvcSession(this HttpSessionState session)
        {
            if (session[MvcSessionKey] == null)
            {
                var mvcSession = new MvcSession();
                mvcSession.Init();
                session[MvcSessionKey] = mvcSession;
                return mvcSession;
            }
            return session[MvcSessionKey] as MvcSession;
        }
    }
}
