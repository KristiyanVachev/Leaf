using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Leaf.Web.Models;

namespace Leaf.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private readonly IAuthenticationProvider authProvider;
        private readonly IUserFactory userFactory;

        public AccountController(IAuthenticationProvider authProvider, IUserFactory userFactory)
        {
            Guard.WhenArgument(authProvider, "AuthenticationProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(userFactory, "UserFactory cannot be null").IsNull().Throw();

            this.authProvider = authProvider;
            this.userFactory = userFactory;
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (this.authProvider.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/Home/Index" : returnUrl;

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = this.authProvider.SignInWithPassword(model.Username, model.Password, model.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return this.Redirect(returnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return this.View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.userFactory.CreateUser(model.Username, model.Email);
                var result = this.authProvider.RegisterAndLoginUser(user, model.Password, isPersistent: false, rememberBrowser: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            this.authProvider.SignOut();

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            this.authProvider.SignOut();

            return this.RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}