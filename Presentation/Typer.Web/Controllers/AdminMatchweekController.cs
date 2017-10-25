using System.Web.Mvc;
using Typer.Services.AdminTeam;
using Typer.ViewModels.AdminMatchweek;

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

        public ActionResult AddNewMatchweek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewMatchweek(VMAdminMatchweekAddNewMatchweek model)
        {
            _adminMatchweekService.AddNewMatchweek(model);
            return RedirectToAction("Index");
        }
    }
}