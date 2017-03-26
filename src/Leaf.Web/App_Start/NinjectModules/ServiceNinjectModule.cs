using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Ninject.Modules;

namespace Leaf.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFullGameService>().To<FullTestService>();
            this.Bind<IQuestionService>().To<QuestionService>();
            this.Bind<ITestService>().To<TestService>();
            this.Bind<ISubmitService>().To<SubmitService>();
            this.Bind<IModerationService>().To<ModerationService>();
            this.Bind<IUserService>().To<UserService>();
        }
    }
}