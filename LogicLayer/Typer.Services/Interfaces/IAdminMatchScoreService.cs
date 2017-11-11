using Typer.ViewModels.Views.AdminMatchScore;

namespace Typer.Services.Interfaces
{
    public interface IAdminMatchScoreService
    {
        VMAdminMatchScoreIndex GetAdminMatchScoreIndex();
        void AddScoreMatch(VMAdminMatchScoreIndex vmMatchScore);
    }
}
