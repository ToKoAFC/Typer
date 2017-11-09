using System.Linq;
using Typer.CoreModels.Models.Match;
using Typer.Database.Access.Access.Match;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatch;

namespace Typer.Services.AdminMatch
{
    public class AdminMatchService
    {
        private AdminMatchAccess _adminMatchAccess;
        public AdminMatchService()
        {
            _adminMatchAccess = new AdminMatchAccess();
        }

        public VMAdminMatchIndex GetAdminMatchIndex()
        {
            var coreMatches = _adminMatchAccess.GetMatches();
            var vmMatches = coreMatches.Select(x => new VMMatch
            {
                MatchId = x.MatchId,
                HomeTeamId = x.HomeTeamId,
                AwayTeamId = x.AwayTeamId,
                MatchweekId = x.MatchweekId,
                AwayTeamName = x.AwayTeamName,
                HomeTeamName = x.HomeTeamName
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
            _adminMatchAccess.CreateMatch(coreModel);
        }


    }
}
