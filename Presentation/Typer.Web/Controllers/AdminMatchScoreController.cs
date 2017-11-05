using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typer.Services.AdminMatch;
using Typer.Services.AdminMatchScore;
using Typer.ViewModels.AdminMatchScore;

namespace Typer.Web.Controllers
{
    public class AdminMatchScoreController : Controller
    {
        private AdminMatchScoreService _adminMatchScoreService;
        private AdminMatchService _adminMatchService;
        public AdminMatchScoreController()
        {
            _adminMatchScoreService = new AdminMatchScoreService();
            _adminMatchService = new AdminMatchService();
        }

        public ActionResult Index()
        {
            var model = _adminMatchScoreService.GetAdminMatchScoreIndex();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new VMAdminMatchScoreCreateMatchScore
            {
                Matches = _adminMatchService.GetAdminMatchIndex()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminMatchScoreCreateMatchScore model)
        {
            _adminMatchScoreService.AddScoreMatch(model);
            return RedirectToAction("Index");
        }
    }
}