using System.Web.Mvc;
using Typer.Services.AdminSeason;
using Typer.ViewModels.AdminSeason;

namespace Typer.Web.Controllers
{
    public class AdminSeasonController : Controller
    {
        public AdminSeasonService _adminSeasonService { get; set; }

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
        public ActionResult AddNewSeason(VMAdminSeasonAddNewSeason model)
        {
            _adminSeasonService.AddNewSeason(model);
            return RedirectToAction("Index");
        }
    }
}