using Leaf.Auth;
using Leaf.Auth.Managers;
using Leaf.Commom.Contracts;

namespace Leaf.Tests.Auth.AuthenticationProviderTests.Mocks
{
    public class MockedAuthenticationProvider : AuthenticationProvider
    {
        public MockedAuthenticationProvider(IHttpContextProvider httpContextProvider): base(httpContextProvider)
        {
        }

        public ApplicationSignInManager GetSignInManager()
        {
            return this.SignInManager;
        }

        public ApplicationUserManager GetUserManager()
        {
            return this.UserManager;
        }
    }
}
