using System.Collections.Generic;
using Typer.CoreModels;
using Typer.CoreModels.Models;

namespace Typer.Database.Access
{
    public interface ITeamAccess
    {
        void AddTeam(CoreNewTeam coreTeam);
        List<CoreTeam> GetTeams();
        CoreTeam GetTeam(int teamId);
         
    }
}
