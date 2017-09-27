using Ninject.Modules;
using Leaf.Factories;
using Leaf.Services.Helpers;
using Leaf.Web.Models;
using Ninject.Extensions.Factory;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITestFactory>().ToFactory().InSingletonScope();
            this.Bind<ISubmitFactory>().ToFactory().InSingletonScope();
            this.Bind<IQuestionFactory>().ToFactory().InSingletonScope();
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();

            this.Bind<IHelperFactory>().ToFactory().InSingletonScope();

            this.Bind<IViewModelFactory>().ToFactory().InSingletonScope();
        }
    }
}