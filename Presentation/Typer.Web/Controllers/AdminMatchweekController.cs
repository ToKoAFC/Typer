using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.AdminMatchweek;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class AdminMatchweekController : Controller
    {
        private readonly IAdminSeasonService _adminSeasonService;
        private readonly IAdminMatchweekService _adminMatchweekService;

        public AdminMatchweekController(IAdminSeasonService adminSeasonService, 
                                        IAdminMatchweekService adminMatchweekService)
        {
            _adminSeasonService = adminSeasonService;
            _adminMatchweekService = adminMatchweekService;
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