using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access.Access
{
    public class TeamAccess
    {
        private TyperContext _context;
        public TeamAccess(TyperContext context)
        {
            _context = context;
        }

        public void AddTeam(CoreTeam coreTeam)
        {
            var dbTeam = new DbTeam
            {
                TeamId = coreTeam.TeamId,
                TeamName = coreTeam.TeamName
            };
            _context.DbTeams.Add(dbTeam);
            _context.SaveChanges();
        }
    }
}
