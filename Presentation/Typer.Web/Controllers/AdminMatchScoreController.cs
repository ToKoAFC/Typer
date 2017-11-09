using System.Web.Mvc;
using Typer.Services.AdminMatch;
using Typer.Services.AdminMatchScore;
using Typer.ViewModels.Views.AdminMatchScore;

namespace Typer.Web.Controllers
{
    public class AdminMatchScoreController : Controller
    {
        private AdminMatchService _adminMatchService;
        private AdminMatchScoreService _adminMatchScoreService;

        public AdminMatchScoreController()
        {
            _adminMatchScoreService = new AdminMatchScoreService();
            _adminMatchService = new AdminMatchService();
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