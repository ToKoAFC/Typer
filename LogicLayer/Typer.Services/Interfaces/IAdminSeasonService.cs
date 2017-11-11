using System.Web.Mvc;
using Typer.ViewModels.Views.AdminSeason;

namespace Typer.Services.Interfaces
{
    public interface IAdminSeasonService
    {
        VMAdminSeasonIndex GetAdminSeasonIndex();
        void AddNewSeason(VMAdminSeasonCreate season);
        SelectList GetSeasonSelectList();
    }
}
