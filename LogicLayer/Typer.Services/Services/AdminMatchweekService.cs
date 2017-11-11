using System.Linq;
using System.Web.Mvc;
using Typer.CoreModels.Models.Matchweek;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatchweek;

namespace Typer.Services.AdminTeam
{
    public class AdminMatchweekService : IAdminMatchweekService
    {
        private readonly IMatchweekAccess _matchweekAccess;
        private readonly ISeasonAccess _seasonAccess;
        public AdminMatchweekService(IMatchweekAccess matchweekAccess, ISeasonAccess seasonAccess)
        {
            _matchweekAccess = matchweekAccess;
            _seasonAccess = seasonAccess;
        }

        public VMAdminMatchweekIndex GetAdminMatchweekIndex()
        {
            var coreMatchweeks = _matchweekAccess.GetMatchweeks();
            var vmMatchweeks = coreMatchweeks.Select(t => new VMMatchweek
            {
                MatchweekId = t.MatchweekId,
                MatchweekName = t.Name
            }).ToList();
            var model = new VMAdminMatchweekIndex
            {
                Matchweeks = vmMatchweeks
            };
            return model;
        }

        public void CreateMatchweek(VMAdminMatchweekCreate matchweek)
        {
            if (string.IsNullOrWhiteSpace(matchweek.MatchweekName))
            {
                return;
            }
            var coreModel = new CoreNewMatchweek
            {
                MatchweekName = matchweek.MatchweekName,
                SeasonId = matchweek.SeasonId
            };
            _matchweekAccess.AddMatchweek(coreModel);
        }

        public SelectList GetMatchweekSelectList(int seasonId)
        {
            var coreMatchweeks = _matchweekAccess.GetMatchweeks(seasonId);
            var selectListItems = coreMatchweeks.Select(x => new SelectListItem
            {
                Value = x.MatchweekId.ToString(),
                Text = x.Name
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
