using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models;
using Typer.Database.Access.Access;
using Typer.ViewModels.AdminTeam;

namespace Typer.Services.AdminTeam
{
    public class AdminTeamService
    {
        private TeamAccess _teamAccess;
        public AdminTeamService()
        {
            _teamAccess = new TeamAccess();
        }
        public void AddNewTeam(VMAddNewTeam team)
        {
            if (string.IsNullOrWhiteSpace(team.TeamName))
            {
                return;
            }
            var coreModel = new CoreNewTeam(team.TeamName);
            _teamAccess.AddTeam(coreModel);
        }

        public VMShowTeams ShowTeams()
        {
            CoreTeamNames coreNewTeam = _teamAccess.SelectTeamNames();
            var vmShowTeams = new VMShowTeams();
            vmShowTeams.TeamNames = coreNewTeam.TeamName;
            return vmShowTeams;
        }
    }
}
