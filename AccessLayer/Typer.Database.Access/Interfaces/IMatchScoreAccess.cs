using System.Collections.Generic;
using Typer.CoreModels.Models.MatchScore;
using Typer.CoreModels.Models.Score;

namespace Typer.Database.Access
{
    public interface IMatchScoreAccess
    {
        List<CoreMatchScore> GetScores();
        void AddMatchScore(CoreNewMatchScore coreScore);
    }
}
