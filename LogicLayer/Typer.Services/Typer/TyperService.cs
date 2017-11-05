using System.Collections.Generic;
using System.Linq;
using Typer.Database.Access.Access.Match;
using Typer.ViewModels.Common;

namespace Typer.Services.Typer
{
    public class TyperService
    {
        public AdminMatchAccess _adminMatchAccess { get; set; }
        public List<VMMatch> GetTyperIndexMatches(int matchweekId)
        {
            var matches = _adminMatchAccess.GetMatches(matchweekId).Select(x => new VMMatch
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
