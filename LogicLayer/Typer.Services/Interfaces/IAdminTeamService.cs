using System.Web.Mvc;
using Typer.ViewModels.Views.AdminTeam;

namespace Typer.Services.Interfaces
{
    public interface IAdminTeamService
    {
        VMAdminTeamIndex GetVMIndex();
        void AddNewTeam(VMAdminTeamCreate team);
        SelectList GetTeamsSelectList();
    }
}
