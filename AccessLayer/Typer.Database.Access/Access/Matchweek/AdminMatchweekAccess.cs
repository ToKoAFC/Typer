using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models;
using Typer.Database.Migrations;

namespace Typer.Database.Access
{
    public class AdminMatchweekAccess
    {
        private TyperContext _context;
        public AdminMatchweekAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatchweek> GetMatchweeks()
        {
            return _context.DbMatchweeks.Select(x =>
            new CoreMatchweek
            {
                MatchweekId = x.MatchweekId,
                Name = x.Name
            }).ToList();
        }
    }
}
