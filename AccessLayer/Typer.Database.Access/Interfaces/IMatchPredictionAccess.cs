using System.Collections.Generic;
using Typer.CoreModels.Models.Match;
using Typer.CoreModels.Models.MatchPrediciton;
using Typer.CoreModels.Models.MatchPrediction;
using Typer.CoreModels.Models.Statistic;

namespace Typer.Database.Access
{
    public interface IMatchPredictionAccess
    {
        List<CoreMatchPrediction> GetMatchPredictions(string userId);
        void ChangeMatchPrediction(CoreChangeMatchPrediction match);
        void UpdatePredictions(List<CoreMatch> matches);
        List<CoreUserStatistic> GetUsersStatistics(int seasonId);
    }
}
