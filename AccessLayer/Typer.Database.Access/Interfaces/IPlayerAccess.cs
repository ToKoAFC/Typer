using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Player;

namespace Typer.Database.Access
{
    public interface IPlayerAccess
    {
        List<CorePlayer> GetPlayers();
    }
}
