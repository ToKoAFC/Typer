using System.Collections.Generic;
using Typer.CoreModels.Models.MatchPrediction;

namespace Typer.Database.Access
{
    public interface IMatchPredictionAccess
    {
        List<CoreMatchPrediction> GetMatchPredictions(string userId);
    }
}
