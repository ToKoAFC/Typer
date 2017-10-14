using System.Web.Mvc;
using Typer.Services.AdminTeam;

namespace Typer.Web.Controllers
{
    public class AdminMatchweekController : Controller
    {
        private AdminMatchweekService _adminMatchweekService;
        public AdminMatchweekController()
        {
            _adminMatchweekService = new AdminMatchweekService();
        }
        public ActionResult Index()
        {
            var model = _adminMatchweekService.GetAdminMatchweekIndex();
            return View(model);
        }
    }
}