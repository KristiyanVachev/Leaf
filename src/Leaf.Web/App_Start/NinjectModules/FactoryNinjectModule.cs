using Ninject.Modules;
using Leaf.Factories;
using Ninject.Extensions.Factory;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITestFactory>().ToFactory().InSingletonScope();
            this.Bind<ISubmitFactory>().ToFactory().InSingletonScope();
        }
    }
}