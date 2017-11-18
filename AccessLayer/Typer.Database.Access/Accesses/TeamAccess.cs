using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels;
using Typer.CoreModels.Models;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access
{
    public class TeamAccess : ITeamAccess
    {
        private TyperContext _context;
        public TeamAccess()
        {
            _context = new TyperContext();
        }

        public void AddTeam(CoreNewTeam coreTeam)
        {
            var dbTeam = new DbTeam
            {
                TeamName = coreTeam.TeamName
            };
            _context.DbTeams.Add(dbTeam);
            _context.SaveChanges();
        }

        public List<CoreTeam> GetTeams()
        {
            return _context.DbTeams.Select(x => new CoreTeam { TeamId = x.TeamId, TeamName = x.TeamName }).ToList();
        }

        public CoreTeam GetTeam(int teamId)
        {
            var team = _context.DbTeams.FirstOrDefault(x => x.TeamId == teamId);
            return  new CoreTeam {TeamId = team.TeamId, TeamName = team.TeamName};
        }
    }
}
