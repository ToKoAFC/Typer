using System.Collections.Generic;
using System.Linq;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;

namespace Typer.Services.Typer
{
    public class TyperService : ITyperService
    {
        public readonly IMatchAccess _matchAccess;
        public TyperService(IMatchAccess matchAccess)
        {
            _matchAccess = matchAccess;
        }

        public List<VMMatch> GetTyperIndexMatches(int matchweekId)
        {
            var matches = _matchAccess.GetMatches(matchweekId).Select(x => new VMMatch
            {
                AwayTeamId = x.AwayTeamId,
                AwayTeamName = x.AwayTeamName,
                HomeTeamId = x.HomeTeamId,
                HomeTeamName = x.HomeTeamName
            }).ToList();
            return matches;
        }
    }
}
