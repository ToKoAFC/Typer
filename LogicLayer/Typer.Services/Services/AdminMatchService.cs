using System.Linq;
using Typer.CoreModels.Models.Match;
using Typer.CoreModels.Models.MatchPrediction;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatch;

namespace Typer.Services.AdminMatch
{
    public class AdminMatchService : IAdminMatchService
    {
        private readonly IMatchAccess _matchAccess;
        private readonly IMatchPredictionAccess _matchPredictionAccess;

        public AdminMatchService(IMatchAccess matchAccess, IMatchPredictionAccess matchPredictionAccess)
        {
            _matchAccess = matchAccess;
            _matchPredictionAccess = matchPredictionAccess;
        }

        public VMAdminMatchIndex GetAdminMatchIndex()
        {
            var coreMatches = _matchAccess.GetMatches();
            var vmMatches = coreMatches.Select(x => new VMMatch
            {
                MatchId = x.MatchId,
                HomeTeamId = x.HomeTeamId,
                AwayTeamId = x.AwayTeamId,
                MatchweekId = x.MatchweekId,
                AwayTeamName = x.AwayTeamName,
                HomeTeamName = x.HomeTeamName,
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals
            }).ToList();

            var model = new VMAdminMatchIndex
            {
                Matches = vmMatches
            };
            return model;
        }

        public void CreateMatch(VMAdminMatchCreate vmMatch)
        {
            var coreModel = new CoreNewMatch
            {
                HomeTeamId = vmMatch.HomeTeamId,
                AwayTeamId = vmMatch.AwayTeamId,
                MatchweekId = vmMatch.MatchweekId,
                SeasonId = vmMatch.SeasonId,
                MatchDate = vmMatch.MatchDate
            };
            _matchAccess.CreateMatch(coreModel);
        }

        public void CreateMatchScore(VMAdminMatchIndex vmMatchScores)
        {

            var matchPredictions = vmMatchScores.Matches.Select(x => new CoreMatch
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                MatchId = x.MatchId
            }).ToList();
            _matchPredictionAccess.UpdatePredictions(matchPredictions);

            foreach (var match in vmMatchScores.Matches)
            {
                var matchScore = new CoreNewMatchScore
                {
                    AwayTeamGoals = match.AwayTeamGoals,
                    HomeTeamGoals = match.HomeTeamGoals,
                    MatchId = match.MatchId
                };
                _matchAccess.CreateMatchScore(matchScore);
            }
        }
    }
}
