using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typer.Services.AdminSeason;
using Typer.Services.AdminTeam;
using Typer.Services.Typer;
using Typer.ViewModels.Typer;

namespace Typer.Web.Controllers
{
    public class TyperController : Controller
    {
        public AdminMatchweekService _adminMatchweekService { get; set; }
        public AdminSeasonService _adminSeasonService { get; set; }
        public TyperService _typerService { get; set; }
        public ActionResult Index()
        {
            var seasons = _adminSeasonService.GetSeasonSelectList();
            var model = new VMTyperIndex()
            {
                Seasons = seasons,
                Matches = new List<VMTyperIndexMatch>(),
                Matchweeks = new SelectList(new List<string>())
            };
            return View(model);
        }
        public JsonResult GetMatchweekList(int seasonId)
        {
            var seasons = _adminMatchweekService.GetMatchweekSelectList(seasonId);
            return Json(seasons);
        }
        public ActionResult GetMatches(int matchweekId)
        {  
            var matches = _typerService.GetTyperIndexMatches(matchweekId);
            var model = new VMTyperIndex { Matches = matches };
            return PartialView("MatchesListPartial", model);
        }
    }
}