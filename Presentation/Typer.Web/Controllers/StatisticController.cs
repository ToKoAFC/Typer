using System.Web.Mvc;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }
    }
}