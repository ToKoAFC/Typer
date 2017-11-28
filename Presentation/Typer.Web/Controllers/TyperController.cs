using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.Typer;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class TyperController : Controller
    {
        private readonly ITyperService _typerService;

        public TyperController(ITyperService typerService)
        {
            _typerService = typerService;
        }

        public ActionResult Index()
        {
            var model = new VMTyperIndex { Matches = _typerService.GetTyperIndexMatches(User.Identity.GetUserId()) };
            return View(model);
        }

        public ActionResult ChangeMatchPredictions(VMTyperIndex model)
        {
            var userId = User.Identity.GetUserId();
            _typerService.ChangeMatchPredictions(model, userId);
            return RedirectToAction("Index");
        }
    }
}