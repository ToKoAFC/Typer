using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models;
using Typer.CoreModels.Models.Matchweek;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access
{
    public class MatchweekAccess : IMatchweekAccess
    {
        private TyperContext _context;
        public MatchweekAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatchweek> GetMatchweeks(int seasonId)
        {
            return _context.DbMatchweeks.Where(s => s.SeasonId == seasonId).Select(x =>
            new CoreMatchweek
            {
                MatchweekId = x.MatchweekId,
                Name = x.Name
            }).ToList();
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

        public void AddMatchweek(CoreNewMatchweek coreMatchweek)
        {
            var dbMatchweek = new DbMatchweek
            {
                Name = coreMatchweek.MatchweekName,
                SeasonId = coreMatchweek.SeasonId

            };
            _context.DbMatchweeks.Add(dbMatchweek);
            _context.SaveChanges();
        }
    }
}
