using System.Collections.Generic;
using Typer.CoreModels.Models.Match;

namespace Typer.Database.Access
{
    public interface IMatchAccess
    {
        List<CoreMatch> GetMatches();
        List<CoreMatch> GetMatches(int matchweekId);
        void CreateMatch(CoreNewMatch coreMatch);
        void CreateMatchScore(CoreNewMatchScore coreScore);
    }
}
