using System.Web;
using Leaf.Auth.Contracts;
using Leaf.Auth.Managers;
using Leaf.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Leaf.Auth
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public bool IsAuthenticated => HttpContext.Current.User.Identity.IsAuthenticated;

        public string CurrentUserId => HttpContext.Current.User.Identity.GetUserId();

        public string CurrentUserName => HttpContext.Current.User.Identity.GetUserName();

        public bool IsInRole(string userId, string roleName)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            return manager.IsInRole(userId, roleName);
        }

        public IdentityResult AddToRole(string userId, string roleName)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            return manager.AddToRole(userId, roleName);
        }

        public IdentityResult RemoveFromRole(string userId, string roleName)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            return manager.RemoveFromRole(userId, roleName);
        }

        public IdentityResult CreateUser(string email, string password)
        {
            var user = new User { Email = email, UserName = email };
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var result = manager.Create(user, password);

            return result;
        }

        public IdentityResult CreateUser(User user, string password)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var result = manager.Create(user, password);

            return result;
        }

        public void SignIn(User user, bool isPersistent, bool rememberBrowser)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            manager.SignIn(user, isPersistent, rememberBrowser);
        }

        public SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            return manager.PasswordSignIn(email, password, rememberMe, shouldLockout);
        }

        public void SignOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
