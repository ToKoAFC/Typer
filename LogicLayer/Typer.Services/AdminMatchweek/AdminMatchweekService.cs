using System.Linq;
using Typer.Database.Access;
using Typer.ViewModels.AdminMatchweek;
using Typer.ViewModels.AdminTeam;

namespace Typer.Services.AdminTeam
{
    public class AdminMatchweekService
    {
        private AdminMatchweekAccess _adminMatchweekAccess;
        public AdminMatchweekService()
        {
            _adminMatchweekAccess = new AdminMatchweekAccess();
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
    }
}
