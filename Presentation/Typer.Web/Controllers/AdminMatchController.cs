using System.Collections.Generic;
using System.Web.Mvc;
using Typer.Services.AdminMatch;
using Typer.Services.AdminSeason;
using Typer.Services.AdminTeam;
using Typer.ViewModels.Views.AdminMatch;

namespace Typer.Web.Controllers
{
    public class AdminMatchController : Controller
    {
        public AdminMatchService _adminMatchService { get; set; }
        public AdminSeasonService _adminSeasonService { get; set; }
        public AdminMatchweekService _adminMatchweekService { get; set; }
        public AdminTeamService _adminTeamService { get; set; }
        
        public ActionResult Index()
        {
            var model = _adminMatchService.GetAdminMatchIndex();
            return View(model);
        }

        public ActionResult Create()
        {
            var season = _adminSeasonService.GetSeasonSelectList();
            var teams = _adminTeamService.GetTeamsSelectList();
            var model = new VMAdminMatchCreate
            {
                Seasons = season,
                Matchweeks = new SelectList(new List<string>()),
                Teams = teams
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminMatchCreate model)
        {
            _adminMatchService.CreateMatch(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetGameweekList(int seasonId)
        {
            var matchweeks = _adminMatchweekService.GetMatchweekSelectList(seasonId);
            return Json(matchweeks, JsonRequestBehavior.AllowGet);
        }
    }
}