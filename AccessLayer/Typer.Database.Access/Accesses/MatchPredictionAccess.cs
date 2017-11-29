using System;
using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models;
using Typer.CoreModels.Models.MatchPrediciton;
using Typer.CoreModels.Models.MatchPrediction;
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
            var time = DateTime.Now.AddHours(1);
            var matchweekId = _context.DbMatches.Where(x => x.MatchDate > time).Select(x => x.MatchweekId).FirstOrDefault();
            var result = new List<CoreMatchPrediction>();
            if (matchweekId == 0)
            {
                return result;
            }

            result = _context.DbMatchPredictions.Where(x => x.UserId == userId && x.Match.MatchweekId == matchweekId)
                .Select(x => new CoreMatchPrediction
                {
                    AwayTeamGoals = x.AwayTeamGoals,
                    AwayTeamName = x.Match.AwayTeam.TeamName,
                    HomeTeamGoals = x.HomeTeamGoals,
                    HomeTeamName = x.Match.HomeTeam.TeamName,
                    MatchId = x.MatchId,
                    MatchPredictionId = x.MatchPredictionId,
                    MatchDate = x.Match.MatchDate
                }).ToList();

            var myMatchesToPredict = _context.DbMatches
                .Where(x => !x.MatchPredictions.Where(v => v.UserId == userId).Any() && x.MatchweekId == matchweekId)
                .Select(x => new CoreMatchPrediction
                {
                    AwayTeamName = x.AwayTeam.TeamName,
                    HomeTeamName = x.HomeTeam.TeamName,
                    MatchId = x.MatchId,
                    MatchPredictionId = 0,
                    MatchDate = x.MatchDate,                
                }).ToList();
            result.AddRange(myMatchesToPredict);
            result.OrderBy(x => x.MatchDate);
            return result;
        }

        public void ChangeMatchPrediction(CoreChangeMatchPrediction match)
        {
            if (match.MatchPredictionId == 0)
            {
                _context.DbMatchPredictions.Add(new DbMatchPrediction
                {
                    AwayTeamGoals = match.AwayTeamGoals,
                    HomeTeamGoals = match.HomeTeamGoals, 
                    MatchId = match.MatchId,
                    UserId = match.UserId,
                });
                _context.SaveChanges();
                return;
            }
            var dbmatchPrediction = _context.DbMatchPredictions.FirstOrDefault(x => x.MatchPredictionId == match.MatchPredictionId);
            dbmatchPrediction.HomeTeamGoals = match.HomeTeamGoals;
            dbmatchPrediction.AwayTeamGoals = match.AwayTeamGoals;
            _context.SaveChanges();
        }
    }
}
