using System.Linq;
using System.Web.Mvc;
using Typer.CoreModels.Models;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminTeam;

namespace Typer.Services.AdminTeam
{
    public class AdminTeamService : IAdminTeamService
    {
        private readonly ITeamAccess _teamAccess;
        public AdminTeamService(ITeamAccess teamAccess)
        {
            _teamAccess = teamAccess;
        }

        public VMAdminTeamIndex GetVMIndex()
        {
            var coreTeams = _teamAccess.GetTeams();
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
            _teamAccess.AddTeam(coreModel);
        }

        public SelectList GetTeamsSelectList()
        {
            var coreTeams = _teamAccess.GetTeams();
            var selectListItems = coreTeams.Select(x => new SelectListItem
            {
                Value = x.TeamId.ToString(),
                Text = x.TeamName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
