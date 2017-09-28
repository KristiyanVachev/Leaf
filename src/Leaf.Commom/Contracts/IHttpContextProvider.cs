using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using Microsoft.Owin;

namespace Leaf.Commom.Contracts
{
    public interface IHttpContextProvider
    {
        HttpContext CurrentHttpContext { get; }

        IOwinContext CurrentOwinContext { get; }

        IIdentity CurrentIdentity { get; }

        TManager GetUserManager<TManager>();

        Cache ContextCache { get; }
    }
}
