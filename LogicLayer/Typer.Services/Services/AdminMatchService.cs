using System.Linq;
using Typer.CoreModels.Models.Match;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatch;

namespace Typer.Services.AdminMatch
{
    public class AdminMatchService : IAdminMatchService
    {
        private readonly IMatchAccess _matchAccess;

        public AdminMatchService(IMatchAccess matchAccess)
        {
            _matchAccess = matchAccess;
        }

        public VMAdminMatchIndex GetAdminMatchIndex()
        {
            var coreMatches = _matchAccess.GetMatches();
            var vmMatches = coreMatches.Select(x => new VMMatch
            {
                MatchId = x.MatchId,
                HomeTeamId = x.HomeTeamId,
                AwayTeamId = x.AwayTeamId,
                MatchweekId = x.MatchweekId,
                AwayTeamName = x.AwayTeamName,
                HomeTeamName = x.HomeTeamName,
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals
            }).ToList();

            var model = new VMAdminMatchIndex
            {
                Matches = vmMatches
            };
            return model;
        }

        public void CreateMatch(VMAdminMatchCreate vmMatch)
        {
            var coreModel = new CoreNewMatch
            {
                HomeTeamId = vmMatch.HomeTeamId,
                AwayTeamId = vmMatch.AwayTeamId,
                MatchweekId = vmMatch.MatchweekId,
                SeasonId = vmMatch.SeasonId,
                MatchDate = vmMatch.MatchDate
            };
            _matchAccess.CreateMatch(coreModel);
        }        
    }
}
