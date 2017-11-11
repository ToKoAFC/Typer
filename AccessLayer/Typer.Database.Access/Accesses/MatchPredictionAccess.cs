using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models;
using Typer.CoreModels.Models.MatchPrediction;
using Typer.CoreModels.Models.Score;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access
{
    public class MatchPredictionAccess : IMatchPredictionAccess
    {
        private readonly TyperContext _context;
        public MatchPredictionAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatchPrediction> GetMatchPredictions(string userId)
        {
            return _context.DbMatchPredictions.Where(p => p.UserId == userId).Select(p => new CoreMatchPrediction
            {
                MatchPredictionId = p.MatchPredictionId,
                UserId = p.UserId,
                MatchScore = new CoreMatchScore
                {
                    AwayTeamGoals = p.MatchScore != null ? p.MatchScore.AwayTeamGoals : 0, //todo change 0 to null
                    AwayTeamName = p.Match != null ? p.Match.AwayTeam.TeamName : string.Empty,
                    HomeTeamGoals = p.MatchScore != null ? p.MatchScore.HomeTeamGoals : 0, //todo change 0 to null
                    HomeTeamName = p.Match != null ? p.Match.HomeTeam.TeamName : string.Empty,
                    MatchId = p.MatchId,
                    MatchScoreId = p.MatchScoreId
                }
            }).ToList();
        }

        public List<CoreTeam> GetTeams()
        {
            return _context.DbTeams.Select(x => new CoreTeam { TeamId = x.TeamId, TeamName = x.TeamName }).ToList();
        }
    }
}
