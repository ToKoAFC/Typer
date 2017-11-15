using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models;
using Typer.ViewModels.Views.Profile;

namespace Typer.Services.Interfaces
{
    public interface IProfileService
    {
        VMManageIndex GetUserDetails(string userId);
        void ChangeUserDetails(VMManageIndex userDetails);
    }
}
