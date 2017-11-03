using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typer.Services.AdminMatch;
using Typer.Services.AdminSeason;
using Typer.Services.AdminTeam;
using Typer.ViewModels.AdminMatch;

namespace Typer.Web.Controllers
{
    public class AdminMatchController : Controller
    {
        private AdminMatchService _adminMatchService;
        private AdminSeasonService _adminSeasonService;
        private AdminMatchweekService _adminMatchweekService;
        private AdminTeamService _adminTeamService;

        public AdminMatchController()
        {
            _adminMatchService = new AdminMatchService();
            _adminSeasonService = new AdminSeasonService();
            _adminMatchweekService = new AdminMatchweekService();
            _adminTeamService = new AdminTeamService();
        }

        public ActionResult Index()
        {
            var model = _adminMatchService.GetAdminMatchIndex();
            return View(model);
        }

        public ActionResult Create()
        {
            var season = _adminSeasonService.GetSeasonSelectList();
            var matchweeks = _adminMatchweekService.GetMatchweekSelectList();
            var teams = _adminTeamService.GetTeamsSelectList();
            var model = new VMAdminMatchCreateMatch
            {
                Seasons = season,
                Matchweeks = matchweeks,
                Teams = teams
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminMatchCreateMatch model)
        {
            _adminMatchService.CreateMatch(model);
            return RedirectToAction("Index");
        }
    }
}