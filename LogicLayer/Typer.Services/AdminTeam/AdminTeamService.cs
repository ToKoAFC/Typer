using System.Linq;
using Typer.CoreModels.Models;
using Typer.Database.Access;
using Typer.ViewModels.AdminTeam;

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
            var vmTeams = coreTeams.Select(t => new VMAdminTeamIndexTeam
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

        public void AddNewTeam(VMAdminTeamAddNewTeam team)
        {
            if (string.IsNullOrWhiteSpace(team.TeamName))
            {
                return;
            }
            var coreModel = new CoreNewTeam(team.TeamName);
            _adminTeamAccess.AddTeam(coreModel);
        }
        
    }
}
