using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.Database.Access.Access.Match;
using Typer.ViewModels.Typer;

namespace Typer.Services.Typer
{
    public class TyperService
    {
        public AdminMatchAccess _adminMatchAccess { get; set; }
        public List<VMTyperIndexMatch> GetTyperIndexMatches(int matchweekId)
        {
            var matches = _adminMatchAccess.GetMatches(matchweekId).Select(x => new VMTyperIndexMatch
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
