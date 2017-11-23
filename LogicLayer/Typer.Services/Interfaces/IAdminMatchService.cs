using Typer.ViewModels.Views.AdminMatch;

namespace Typer.Services.Interfaces
{
    public interface IAdminMatchService
    {
        VMAdminMatchIndex GetAdminMatchIndex();
        void CreateMatch(VMAdminMatchCreate vmMatch);
    }
}
