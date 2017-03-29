using System.Web.Mvc;

namespace Leaf.Web.Controllers
{
    public class ErrorController : Controller
    {
        [OutputCache(Duration = 60 * 10)]
        public ActionResult NotFound()
        {
            return this.View();
        }

        [OutputCache(Duration = 60 * 10)]
        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}