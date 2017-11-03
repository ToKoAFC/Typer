using System.Web.Mvc;
using Typer.Services.AdminSeason;
using Typer.Services.AdminTeam;
using Typer.ViewModels.AdminMatchweek;

namespace Typer.Web.Controllers
{
    public class AdminMatchweekController : Controller
    {
        private AdminMatchweekService _adminMatchweekService;
        private AdminSeasonService _adminSeasonService;

        public AdminMatchweekController()
        {
            _adminMatchweekService = new AdminMatchweekService();
            _adminSeasonService = new AdminSeasonService();
        }

        public ActionResult Index()
        {
            var model = _adminMatchweekService.GetAdminMatchweekIndex();
            return View(model);
        }

        public ActionResult Create()
        {
            var seasons = _adminSeasonService.GetSeasonSelectList();
            var model = new VMAdminMatchweekCreate
            {
                Seasons = seasons
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminMatchweekCreate model)
        {
            _adminMatchweekService.CreateMatchweek(model);
            return RedirectToAction("Index");
        }
    }
}