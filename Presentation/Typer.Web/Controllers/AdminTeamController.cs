using System.Web.Mvc;
using Typer.Services.AdminTeam;
using Typer.ViewModels.Views.AdminTeam;

namespace Typer.Web.Controllers
{
    public class AdminTeamController : Controller
    {
        public AdminTeamService _adminTeamService { get; set; }

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