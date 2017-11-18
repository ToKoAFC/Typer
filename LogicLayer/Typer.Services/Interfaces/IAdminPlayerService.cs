using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.ViewModels.Views.AdminPlayer;

namespace Typer.Services.Interfaces
{
    public interface IAdminPlayerService
    {
        VMAdminPlayerIndex GetAdminPlayerIndex();
    }
}
