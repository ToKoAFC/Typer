using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.Calendar;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public ActionResult Index()
        {
            var seasonsSelectList = _calendarService.GetSeasonSelectList();
            return View(new VMCalendarIndex { SelectListSeasons = seasonsSelectList });
        }

        [HttpGet]
        public PartialViewResult GetMatches(int seasonId)
        {
            var model = _calendarService.GetCalendarIndex(seasonId);
            return PartialView("CalendarPartial", model);
        }        
    }
}