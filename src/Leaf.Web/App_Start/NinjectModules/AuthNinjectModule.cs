using Leaf.Auth;
using Leaf.Auth.Contracts;
using Ninject.Modules;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class AuthNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticationProvider>().To<AuthenticationProvider>().InSingletonScope();
        }
    }
}