using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Ninject.Modules;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFullGameService>().To<FullGameService>();
        }
    }
}