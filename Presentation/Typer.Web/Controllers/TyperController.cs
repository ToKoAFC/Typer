using System.Collections.Generic;
using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.Typer;

namespace Typer.Web.Controllers
{
    public class TyperController : Controller
    {
        private readonly IAdminMatchweekService _adminMatchweekService;
        private readonly IAdminSeasonService _adminSeasonService;
        private readonly ITyperService _typerService;

        public TyperController(IAdminMatchweekService adminMatchweekService, 
                                IAdminSeasonService adminSeasonService,
                                ITyperService typerService)
        {
            _adminMatchweekService = adminMatchweekService;
            _adminSeasonService = adminSeasonService;
            _typerService = typerService;
        }

        public ActionResult Index()
        {
            var seasons = _adminSeasonService.GetSeasonSelectList();
            var model = new VMTyperIndex()
            {
                Seasons = seasons,
                Matches = new List<VMMatch>(),
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