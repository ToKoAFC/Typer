using System.Linq;
using System.Web.Mvc;
using Typer.CoreModels.Models.Matchweek;
using Typer.Database.Access;
using Typer.Database.Access.Access.Season;
using Typer.ViewModels.AdminMatchweek;

namespace Typer.Services.AdminTeam
{
    public class AdminMatchweekService
    {
        private AdminMatchweekAccess _adminMatchweekAccess;
        private AdminSeasonAcess _adminSeasonAcess;
        public AdminMatchweekService()
        {
            _adminMatchweekAccess = new AdminMatchweekAccess();
            _adminSeasonAcess = new AdminSeasonAcess();
        }

        public VMAdminMatchweekIndex GetAdminMatchweekIndex()
        {
            var coreMatchweeks = _adminMatchweekAccess.GetMatchweeks();
            var vmMatchweeks = coreMatchweeks.Select(t => new VMAdminMatchweekIndexMatchweek
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
            _adminMatchweekAccess.AddMatchweek(coreModel);
        }

        public SelectList GetMatchweekSelectList()
        {
            var coreMatchweeks = _adminMatchweekAccess.GetMatchweeks();
            var selectListItems = coreMatchweeks.Select(x => new SelectListItem
            {
                Value = x.MatchweekId.ToString(),
                Text = x.Name
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
