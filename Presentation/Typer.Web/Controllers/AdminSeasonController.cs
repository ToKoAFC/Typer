using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typer.Services.AdminSeason;
using Typer.ViewModels.AdminSeason;

namespace Typer.Web.Controllers
{
    public class AdminSeasonController : Controller
    {
        private AdminSeasonService _adminSeasonService;
        public AdminSeasonController()
        {
            _adminSeasonService = new AdminSeasonService();
        }

        public ActionResult Index()
        {
            var model = _adminSeasonService.GetAdminSeasonIndex();
            return View(model);
        }

        public ActionResult AddNewSeason()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewSeason(VMAdminSeasonAddNewSeason model)
        {
            _adminSeasonService.AddNewSeason(model);
            return RedirectToAction("Index");
        }
    }
}