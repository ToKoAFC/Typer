using System.Web.Mvc;
using Typer.Services.AdminSeason;
using Typer.Services.AdminTeam;
using Typer.ViewModels.Views.AdminMatchweek;

namespace Typer.Web.Controllers
{
    public class AdminMatchweekController : Controller
    {
        public AdminSeasonService _adminSeasonService { get; set; }
        public AdminMatchweekService _adminMatchweekService { get; set; }

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