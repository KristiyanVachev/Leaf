using Leaf.Data;
using Leaf.Data.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILeafDbContext>().To<LeafDbContext>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
        }
    }
}