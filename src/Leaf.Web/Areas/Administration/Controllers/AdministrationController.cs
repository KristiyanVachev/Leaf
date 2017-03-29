using System.Web.Mvc;
using Leaf.Commom;

namespace Leaf.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = Constants.Administrator)]
    public class AdministrationController : Controller
    {
        // GET: Administration/Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}