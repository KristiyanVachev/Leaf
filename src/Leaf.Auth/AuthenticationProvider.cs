using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Auth.Managers;
using Leaf.Commom.Contracts;
using Leaf.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Leaf.Auth
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IHttpContextProvider httpContextProvider;

        public AuthenticationProvider(IHttpContextProvider httpContextProvider)
        {
            Guard.WhenArgument(httpContextProvider, "httpContextProvider cannot be null").IsNull().Throw();

            this.httpContextProvider = httpContextProvider;
        }

        protected ApplicationSignInManager SignInManager => this.httpContextProvider.GetUserManager<ApplicationSignInManager>();

        protected ApplicationUserManager UserManager => this.httpContextProvider.GetUserManager<ApplicationUserManager>();

        public bool IsAuthenticated => this.httpContextProvider.CurrentIdentity.IsAuthenticated;

        public string CurrentUserId => this.httpContextProvider.CurrentIdentity.GetUserId();

        public string CurrentUserName => this.httpContextProvider.CurrentIdentity.GetUserName();

        public bool IsInRole(string userId, string roleName)
        {
            return userId != null && this.UserManager.IsInRole(userId, roleName);
        }

        public IdentityResult AddToRole(string userId, string roleName)
        {
            return this.UserManager.AddToRole(userId, roleName);
        }

        public IdentityResult RemoveFromRole(string userId, string roleName)
        {
            return this.UserManager.RemoveFromRole(userId, roleName);
        }

        public IdentityResult CreateUser(User user, string password)
        {
            return this.UserManager.Create(user, password);
        }

        public void SignIn(User user, bool isPersistent, bool rememberBrowser)
        {
            this.SignInManager.SignIn(user, isPersistent, rememberBrowser);
        }

        public SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout)
        {
            return this.SignInManager.PasswordSignIn(email, password, rememberMe, shouldLockout);
        }

        public IdentityResult RegisterAndLoginUser(User user, string password, bool isPersistent, bool rememberBrowser)
        {
            var result = this.UserManager.Create(user, password);

            if (result.Succeeded)
            {
                this.SignInManager.SignIn(user, isPersistent, rememberBrowser);
            }

            return result;
        }

        public void SignOut()
        {
            this.httpContextProvider.CurrentOwinContext.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
