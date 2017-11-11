using System.Web.Mvc;
using Typer.Services.AdminMatch;
using Typer.Services.AdminMatchScore;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.AdminMatchScore;

namespace Typer.Web.Controllers
{
    public class AdminMatchScoreController : Controller
    {
        private readonly IAdminMatchService _adminMatchService;
        private readonly IAdminMatchScoreService _adminMatchScoreService;

        public AdminMatchScoreController(IAdminMatchService adminMatchService, IAdminMatchScoreService adminMatchScoreService)
        {
            _adminMatchService = adminMatchService;
            _adminMatchScoreService = adminMatchScoreService;
        }
       
        public ActionResult Index()
        {
            var model = _adminMatchScoreService.GetAdminMatchScoreIndex();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = _adminMatchScoreService.GetAdminMatchScoreIndex();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminMatchScoreIndex model)
        {
            _adminMatchScoreService.AddScoreMatch(model);
            return RedirectToAction("Index");
        }
    }
}