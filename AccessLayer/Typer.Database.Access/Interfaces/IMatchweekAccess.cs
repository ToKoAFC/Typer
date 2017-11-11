using System.Collections.Generic;
using Typer.CoreModels.Models;
using Typer.CoreModels.Models.Matchweek;

namespace Typer.Database.Access
{
    public interface IMatchweekAccess
    {
        List<CoreMatchweek> GetMatchweeks(int seasonId);
        List<CoreMatchweek> GetMatchweeks();
        void AddMatchweek(CoreNewMatchweek coreMatchweek);
    }
}
