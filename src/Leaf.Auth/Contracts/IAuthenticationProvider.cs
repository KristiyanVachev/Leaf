using Leaf.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Leaf.Auth.Contracts
{
    public interface IAuthenticationProvider
    {
        bool IsAuthenticated { get; }

        string CurrentUserId { get; }

        string CurrentUserName { get; }

        bool IsInRole(string userId, string roleName);

        IdentityResult AddToRole(string userId, string roleName);

        IdentityResult RemoveFromRole(string userId, string roleName);

        IdentityResult CreateUser(User user, string password);

        void SignIn(User user, bool isPersistent, bool rememberBrowser);

        SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout);

        void SignOut();
    }
}
