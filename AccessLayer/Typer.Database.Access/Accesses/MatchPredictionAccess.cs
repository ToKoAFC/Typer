using System;
using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models.Match;
using Typer.CoreModels.Models.MatchPrediciton;
using Typer.CoreModels.Models.MatchPrediction;
using Typer.CoreModels.Models.Statistic;
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

        public List<CoreMatchPrediction> GetMatchPredictions(string userId) //todo Mikołaj, add param matchweekdId and change method logic
        {
            var result = new List<CoreMatchPrediction>();
            var matchweekId = _context.DbMatches
                                        .Where(x => x.MatchDate > DateTime.Now.AddHours(1))
                                        .OrderBy(x => x.MatchDate)
                                        .Select(x => x.MatchweekId)
                                        .FirstOrDefault();
            if (matchweekId != 0)
            {
                result = _context.DbMatches
                .Where(x => x.MatchweekId == matchweekId)
                .OrderBy(x => x.MatchDate)
                .Select(x => new CoreMatchPrediction
                {
                    AwayTeamGoals = x.MatchPredictions.Any(p => p.UserId == userId) ? x.MatchPredictions.FirstOrDefault(p => p.UserId == userId).AwayTeamGoals : null,
                    AwayTeamName = x.AwayTeam != null ? x.AwayTeam.TeamName : "Unknown",
                    HomeTeamGoals = x.MatchPredictions.Any(p => p.UserId == userId) ? x.MatchPredictions.FirstOrDefault(p => p.UserId == userId).HomeTeamGoals : null,
                    HomeTeamName = x.HomeTeam != null ? x.HomeTeam.TeamName : "Unknown",
                    MatchId = x.MatchId,
                    MatchPredictionId = x.MatchPredictions.Any(p => p.UserId == userId) ? x.MatchPredictions.FirstOrDefault(p => p.UserId == userId).MatchPredictionId : 0,
                    MatchDate = x.MatchDate
                })
                .ToList();
            }
            return result;
        }

        public void ChangeMatchPrediction(CoreChangeMatchPrediction match)
        {
            if (match.MatchPredictionId == 0) //todo Mikołaj, change if condition and switch codes
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

        public void UpdatePredictions(List<CoreMatch> matches) //todo Mikołaj, remove that shit
        {
            foreach (var match in matches)
            {
                var matchPredictions = _context.DbMatchPredictions
                                    .Where(x => x.MatchId == match.MatchId &&
                                          (x.Match.HomeTeamGoals != match.HomeTeamGoals ||
                                          x.Match.AwayTeamGoals != match.AwayTeamGoals))
                                    .ToList();

                if (matchPredictions == null)
                    continue;

                foreach (var matchPrediction in matchPredictions)
                {
                    if (matchPrediction.HomeTeamGoals == match.HomeTeamGoals && matchPrediction.AwayTeamGoals == match.AwayTeamGoals)
                    {
                        matchPrediction.Points = 3;
                        continue;
                    }

                    if ((matchPrediction.HomeTeamGoals > matchPrediction.AwayTeamGoals && match.HomeTeamGoals > match.AwayTeamGoals) ||
                        (matchPrediction.HomeTeamGoals < matchPrediction.AwayTeamGoals && match.HomeTeamGoals < match.AwayTeamGoals) ||
                        (matchPrediction.HomeTeamGoals == matchPrediction.AwayTeamGoals && match.HomeTeamGoals == match.AwayTeamGoals))
                    {
                        matchPrediction.Points = 1;
                        continue;
                    }
                    matchPrediction.Points = 0;
                }
                _context.SaveChanges();
            }
        }

        public List<CoreUserStatistic> GetUsersStatistics(int seasonId) //todo Mikołaj, update this method
        {
            var stats = _context.DbAppUsers.Select(x => new CoreUserStatistic
            {
                Username = x.UserName,
                UserPoints = x.MatchPredictions
                                .Where(p =>
                                p.Match == null ? false :
                                p.Match.Matchweek == null ? false : p.Match.Matchweek.SeasonId == seasonId)
                                .Select(v => v.Points).Sum()
            }).ToList();
            return stats;
        }
    }
}
