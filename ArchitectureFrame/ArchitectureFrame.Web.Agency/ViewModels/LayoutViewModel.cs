using ArchitectureFrame.Infrastructure.Core;
using ArchitectureFrame.Infrastructure.Extensions;
using ArchitectureFrame.Web.Agency.Extensions;
using ArchitectureFrame.Web.Agency.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArchitectureFrame.Web.Agency.ViewModels
{
    public class LayoutViewModel
    {
        public string Title { get; set; }
        public string Error { get; set; }

        public MvcSession GetSession()
        {
            return HttpContext.Current.Session.GetMvcSession();
        }

        public bool HasError => !string.IsNullOrEmpty(this.Error);

        protected int GetUserId()
        {
            return HttpContext.Current.Request.GetUserIdfromSession();
        }

        public void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                this.Error = (ex is KnownException) ? ex.Message : ex.GetAllMessages();
            }
        }
    }

    public class LayoutViewModel<T> : LayoutViewModel
    {
        public T Model { get; set; }
    }
}
