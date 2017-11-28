using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models.MatchPrediciton;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.Typer;

namespace Typer.Services.Typer
{
    public class TyperService : ITyperService
    {
        public readonly IMatchPredictionAccess _matchPredictionAccess;
        public TyperService(IMatchPredictionAccess matchPredictionAccess)
        {
            _matchPredictionAccess = matchPredictionAccess;
        }

        public List<VMMatchPrediction> GetTyperIndexMatches(string user)
        {
            var matches = _matchPredictionAccess.GetMatchPredictions(user).Select(x => new VMMatchPrediction
            {
                AwayTeamGoals = x.AwayTeamGoals,
                AwayTeamName = x.AwayTeamName,
                HomeTeamGoals = x.HomeTeamGoals,
                HomeTeamName = x.HomeTeamName,
                MatchDate = x.MatchDate,
                MatchId = x.MatchId,
                MatchPredictionId = x.MatchPredictionId
            }).ToList();
            return matches;
        }

        public void ChangeMatchPredictions(VMTyperIndex model, string userId)
        {
            var matchPredictions = model.Matches.Select(x => new CoreChangeMatchPrediction
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                MatchPredictionId = x.MatchPredictionId,
                UserId = userId,
                MatchId = x.MatchId
            }).ToList();
            matchPredictions.ForEach(x => _matchPredictionAccess.ChangeMatchPrediction(x));
          
        }
    }
}
