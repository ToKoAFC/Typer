using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models.MatchScore;
using Typer.CoreModels.Models.Score;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access.Access.MatchScore
{
    public class AdminMatchScoreAccess
    {
        private TyperContext _context;

        public AdminMatchScoreAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatchScore> GetScores()
        {
            return _context.DbScores.Select(x => new CoreMatchScore
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                MatchId = x.MatchId,
                MatchScoreId = x.MatchScoreId,
                AwayTeamName = x.Match.AwayTeam.TeamName,
                HomeTeamName = x.Match.HomeTeam.TeamName
            }).ToList();
        }

        public void AddMatchScore(CoreNewMatchScore coreScore)
        {
            var dbMatchScore = new DbMatchScore
            {
                AwayTeamGoals = coreScore.AwayTeamGoals,
                HomeTeamGoals = coreScore.HomeTeamGoals,
                MatchScoreId = coreScore.MatchScoreId,
                MatchId = coreScore.MatchId
            };
            _context.DbScores.Add(dbMatchScore);
            _context.SaveChanges();
        }
    }
}
