using System.Collections.Generic;
using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.AdminMatch;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class AdminMatchController : Controller
    {
        private readonly IAdminMatchService _adminMatchService;
        private readonly IAdminSeasonService _adminSeasonService;
        private readonly IAdminMatchweekService _adminMatchweekService;
        private readonly IAdminTeamService _adminTeamService;

        public AdminMatchController(IAdminMatchService adminMatchService,
                                    IAdminSeasonService adminSeasonService,
                                    IAdminMatchweekService adminMatchweekService,
                                    IAdminTeamService adminTeamService)
        {
            _adminMatchService = adminMatchService;
            _adminSeasonService = adminSeasonService;
            _adminMatchweekService = adminMatchweekService;
            _adminTeamService = adminTeamService;
        }

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