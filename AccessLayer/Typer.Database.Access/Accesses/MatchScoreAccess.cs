using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models.MatchScore;
using Typer.CoreModels.Models.Score;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access
{
    public class MatchScoreAccess : IMatchScoreAccess
    {
        private TyperContext _context;

        public MatchScoreAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatchScore> GetScores()
        {
            var model = _context.DbScores.Select(x => new CoreMatchScore
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                MatchId = x.MatchId,
                AwayTeamName = x.Match.AwayTeam.TeamName,
                HomeTeamName = x.Match.HomeTeam.TeamName
            }).ToList();

            return model;
        }

        public void AddMatchScore(CoreNewMatchScore coreScore)
        {
            var dbMatchScore = _context.DbScores.FirstOrDefault(x => x.MatchId == coreScore.MatchId);
            dbMatchScore.HomeTeamGoals = coreScore.HomeTeamGoals;
            dbMatchScore.AwayTeamGoals = coreScore.AwayTeamGoals;
            _context.SaveChanges();            
        }
        
    }
}
