using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.AdminSeason;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class AdminSeasonController : Controller
    {
        private readonly IAdminSeasonService _adminSeasonService;
        public AdminSeasonController(IAdminSeasonService adminSeasonService)
        {
            _adminSeasonService = adminSeasonService;
        }

        public ActionResult Index()
        {
            var model = _adminSeasonService.GetAdminSeasonIndex();
            return View(model);
        }

        public ActionResult AddNewSeason()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewSeason(VMAdminSeasonCreate model)
        {
            _adminSeasonService.AddNewSeason(model);
            return RedirectToAction("Index");
        }
    }
}