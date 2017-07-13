using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Administration.Models;
using PagedList;

namespace Leaf.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = Constants.Administrator)]
    public class UsersAdministrationController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthenticationProvider authenticationProvider;

        public UsersAdministrationController(IUserService userService, IAuthenticationProvider authenticationProvider)
        {
            Guard.WhenArgument(userService, "userService cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "authenticationProvider cannot be null").IsNull().Throw();

            this.userService = userService;
            this.authenticationProvider = authenticationProvider;
        }

        // GET: Administration/UsersAdministration
        public ActionResult Index(int page = 1, int count = 10)
        {
            var users = this.userService.GetAll();

            var model = users.Select(x => new UserViewModel(x.Id,
                x.UserName,
                this.authenticationProvider.IsInRole(x.Id, Constants.Moderator),
                this.authenticationProvider.IsInRole(x.Id, Constants.Administrator)));

            return this.View(model.ToPagedList(page, count));
        }


        public ActionResult RemoveRole(string userId, string roleName, int page)
        {
            this.authenticationProvider.RemoveFromRole(userId, roleName);

            return this.RedirectToAction("Index", new { page = page });
        }

        public ActionResult AddRole(string userId, string roleName, int page)
        {
            this.authenticationProvider.AddToRole(userId, roleName);

            return this.RedirectToAction("Index", new { page = page });
        }
    }
}