using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.Statisctic;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public ActionResult Index()
        {
            var seasons = _statisticService.GetSeasonSelectList();
            var model = new VMStatisticIndex { Seasons = seasons };
            return View(model);
        }

        [HttpGet]
        public PartialViewResult GetStatistics(int seasonId)
        {
            var statistics = _statisticService.GetUserStatistics(User.Identity.GetUserId(), seasonId);
            var model = new VMStatisticIndex { UserStatistics = statistics };
            return PartialView("StatisticsPartial", model);
        }
    }
}