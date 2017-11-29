using System.Collections.Generic;
using Typer.CoreModels.Models.Match;
using Typer.CoreModels.Models.Season;

namespace Typer.Database.Access
{
    public interface IMatchAccess
    {
        List<CoreMatch> GetMatches();
        List<CoreMatch> GetMatches(int matchweekId);
        List<CoreMatch> GetMatches(CoreSeason season);
        void CreateMatch(CoreNewMatch coreMatch);
        void CreateMatchScore(CoreNewMatchScore coreScore);
    }
}
