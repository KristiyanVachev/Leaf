using Leaf.Services;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities;
using Leaf.Services.Utilities.Contracts;
using Ninject.Modules;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITestService>().To<TestService>();
            this.Bind<ISubmitService>().To<SubmitService>();
            this.Bind<IModerationService>().To<ModerationService>();

            this.Bind<ITestUtility>().To<TestUtility>();
            this.Bind<IQuestionUtility>().To<QuestionUtility>();
            this.Bind<IUserUtility>().To<UserUtility>();
        }
    }
}