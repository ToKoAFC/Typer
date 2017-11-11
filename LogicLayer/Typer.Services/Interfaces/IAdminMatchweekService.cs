using System.Web.Mvc;
using Typer.ViewModels.Views.AdminMatchweek;

namespace Typer.Services.Interfaces
{
    public interface IAdminMatchweekService
    {
        VMAdminMatchweekIndex GetAdminMatchweekIndex();
        void CreateMatchweek(VMAdminMatchweekCreate matchweek);
        SelectList GetMatchweekSelectList(int seasonId);
    }
}
