using System.Web.Mvc;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }       
    }
}