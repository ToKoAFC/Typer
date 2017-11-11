using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.AdminTeam;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class AdminTeamController : Controller
    {
        private readonly IAdminTeamService _adminTeamService;

        public AdminTeamController(IAdminTeamService adminTeamService)
        {
            _adminTeamService = adminTeamService;
        }

        public ActionResult Index()
        {
            var model = _adminTeamService.GetVMIndex();
            return View(model);
        }

        public ActionResult AddNewTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewTeam(VMAdminTeamCreate model)
        {
            _adminTeamService.AddNewTeam(model);
            return RedirectToAction("Index");
        }
    }
}