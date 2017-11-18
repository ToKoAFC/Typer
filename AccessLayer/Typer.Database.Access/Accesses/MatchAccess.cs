using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models.Match;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access
{
    public class MatchAccess : IMatchAccess
    {  
        private TyperContext _context;
        public MatchAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatch> GetMatches()
        {
            return _context.DbMatches.Select(x => new CoreMatch
            {
                MatchId = x.MatchId,
                AwayTeamId = x.AwayTeamId,
                HomeTeamId = x.HomeTeamId,
                MatchweekId = x.MatchweekId,
                AwayTeamName = x.AwayTeam.TeamName,
                HomeTeamName = x.HomeTeam.TeamName
            }).ToList();
        }
        public List<CoreMatch> GetMatches(int matchweekId)
        {
            var matches = _context.DbMatches.Where(x => x.MatchweekId == matchweekId).Select(x => new CoreMatch
            {
                AwayTeamId = x.AwayTeamId,
                HomeTeamId = x.HomeTeamId,
                MatchweekId = x.MatchweekId,
                AwayTeamName = x.AwayTeam.TeamName,
                HomeTeamName = x.HomeTeam.TeamName
            }).ToList();
            return matches;
        }

        public void CreateMatch(CoreNewMatch coreMatch)
        {
            var dbMatch = new DbMatch
            {
                MatchweekId = coreMatch.MatchweekId,
                HomeTeamId = coreMatch.HomeTeamId,
                AwayTeamId = coreMatch.AwayTeamId,
                MatchDate = coreMatch.MatchDate,
                MatchScore = new DbMatchScore()
            };
            _context.DbMatches.Add(dbMatch);                       
            _context.SaveChanges();
        }
    }
}
