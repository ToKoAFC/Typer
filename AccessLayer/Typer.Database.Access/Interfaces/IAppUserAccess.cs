using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models;

namespace Typer.Database.Access
{
    public interface IAppUserAccess
    {
        CoreUserDetails GetUserDetails(string userId);
        void ChangeUserDetails(CoreChangeUserDetails userDetails);
    }
}
