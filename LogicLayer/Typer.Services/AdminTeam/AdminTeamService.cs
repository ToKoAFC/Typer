using System.Linq;
using System.Web.Mvc;
using Typer.CoreModels.Models;
using Typer.Database.Access;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminTeam;

namespace Typer.Services.AdminTeam
{
    public class AdminTeamService
    {
        private TeamAccess _adminTeamAccess;
        public AdminTeamService()
        {
            _adminTeamAccess = new TeamAccess();
        }

        public VMAdminTeamIndex GetVMIndex()
        {
            var coreTeams = _adminTeamAccess.GetTeams();
            var vmTeams = coreTeams.Select(t => new VMATeam
            {
                TeamId = t.TeamId,
                TeamName = t.TeamName
            }).ToList();
            var model = new VMAdminTeamIndex
            {
                Teams = vmTeams
            };
            return model;
        }

        public void AddNewTeam(VMAdminTeamCreate team)
        {
            if (string.IsNullOrWhiteSpace(team.TeamName))
            {
                return;
            }
            var coreModel = new CoreNewTeam
            {
                TeamName = team.TeamName
            };
            _adminTeamAccess.AddTeam(coreModel);
        }

        public SelectList GetTeamsSelectList()
        {
            var coreTeams = _adminTeamAccess.GetTeams();
            var selectListItems = coreTeams.Select(x => new SelectListItem
            {
                Value = x.TeamId.ToString(),
                Text = x.TeamName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
