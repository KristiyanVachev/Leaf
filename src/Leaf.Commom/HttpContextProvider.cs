using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Leaf.Commom.Contracts;

namespace Leaf.Commom
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext CurrentHttpContext => HttpContext.Current;

        public IOwinContext CurrentOwinContext => HttpContext.Current.GetOwinContext();

        public IIdentity CurrentIdentity => HttpContext.Current.User.Identity;

        public TManager GetUserManager<TManager>()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<TManager>();
        }

        public Cache ContextCache => HttpContext.Current.Cache;
    }
}
