using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typer.Services.AdminTeam;
using Typer.ViewModels.AdminTeam;

namespace Typer.Web.Controllers
{
    public class AdminTeamController : Controller
    {
        private AdminTeamService _adminTeamService;
        public AdminTeamController()
        {
            _adminTeamService = new AdminTeamService();
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
        public ActionResult AddNewTeam(VMAdminTeamAddNewTeam model)
        {
            _adminTeamService.AddNewTeam(model);
            return RedirectToAction("Index");
        }
    }
}