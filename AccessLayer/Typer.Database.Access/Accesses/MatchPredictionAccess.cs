using System;
using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models;
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

        public List<CoreMatchPrediction> GetMatchPredictions(string userId)
        {
            var time = DateTime.Now.AddHours(1);
            var matchweekId = _context.DbMatches.Where(x => x.MatchDate > time).OrderBy(x => x.MatchDate)
                .Select(x => x.MatchweekId).FirstOrDefault();
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

        public void UpdatePredictions(List<CoreMatch> matches)
        {
            foreach (var match in matches)
            {
                var matchPredictions = _context.DbMatchPredictions.Where(x => x.MatchId == match.MatchId &&
                (x.Match.HomeTeamGoals != match.HomeTeamGoals || x.Match.AwayTeamGoals != match.AwayTeamGoals)).ToList();

                if (matchPredictions == null)
                    continue;

                foreach(var matchPrediction in matchPredictions)
                {
                    if(matchPrediction.HomeTeamGoals == match.HomeTeamGoals && matchPrediction.AwayTeamGoals == match.AwayTeamGoals)
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

        public List<CoreUserStatistic> GetUsetStatistics(int seasonId)
        {
            var statistics = new List<CoreUserStatistic>();
            var userIds = new List<string>();

            var predictions = _context.DbMatchPredictions.Where(x => x.Match.Matchweek.SeasonId == seasonId)
                .Select(x => new CoreMatchPrediction
                {
                    UserId = x.UserId,
                    Points = x.Points
                }).ToList();

            foreach(var prediction in predictions)
            {
                if (userIds.Contains(prediction.UserId))
                    continue;

                int? userPoints;
                userPoints = 0;

                var userPredictions = predictions.Where(x => x.UserId == prediction.UserId)
                .Select(z => new CoreMatchPrediction
                {
                    Points = z.Points
                }).ToList();

                userPredictions.ForEach(x => userPoints += x.Points);

                var username = _context.DbAppUsers.FirstOrDefault(x => x.Id == prediction.UserId).UserName;
                userIds.Add(prediction.UserId);
                statistics.Add(new CoreUserStatistic
                {
                    Username = username,
                    UserPoints = userPoints
                });
            }
            return statistics.OrderByDescending(x => x.UserPoints).ToList();
        }
    }
}
