using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Match;
using Typer.Database.Access.Access.Match;
using Typer.ViewModels.AdminMatch;

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
            var vmMatches = coreMatches.Select(x => new VMAdminMatchIndexMatch
            {
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

        public void CreateMatch(VMAdminMatchCreateMatch vmMatch)
        {
            var coreModel = new CoreNewMatch
            {
                HomeTeamId = vmMatch.HomeTeamId,
                AwayTeamId = vmMatch.AwayTeamId,
                MatchweekId = vmMatch.MatchweekId,
                SeasonId = vmMatch.SeasonId
            };
            _adminMatchAccess.CreateMatch(coreModel);
        }


    }
}
