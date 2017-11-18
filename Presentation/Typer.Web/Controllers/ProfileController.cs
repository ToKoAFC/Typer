using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.Profile;

namespace Typer.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _userProfileService;
        private readonly IAdminTeamService _adminTeamService;

        public ProfileController (IProfileService userProfileService, IAdminTeamService adminTeamService)
        {
            _userProfileService = userProfileService;
            _adminTeamService = adminTeamService;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var model = _userProfileService.GetUserDetails(userId);
            model.SelectListTeams = _adminTeamService.GetTeamsSelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeDetails(VMManageIndex details)
        {
            details.Id = User.Identity.GetUserId();
            _userProfileService.ChangeUserDetails(details);
            return RedirectToAction("Index");
        }
    }
}