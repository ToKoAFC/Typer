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
            return View();
        }

        public ActionResult ShowTeams()
        {
            VMShowTeams vmTeamNames = new VMShowTeams();
            vmTeamNames = _adminTeamService.ShowTeams();
            return View(vmTeamNames);
        }
              
        [HttpPost]
        public ActionResult AddNewTeam(VMAddNewTeam model)
        {
            _adminTeamService.AddNewTeam(model);
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}