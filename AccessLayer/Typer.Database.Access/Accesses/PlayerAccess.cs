using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Player;
using Typer.Database.Migrations;

namespace Typer.Database.Access
{
    public class PlayerAccess : IPlayerAccess
    {
        private TyperContext _context;

        public PlayerAccess()
        {
            _context = new TyperContext();
        }

        public List<CorePlayer> GetPlayers()
        {
            return _context.DbPlayers.Select(x => new CorePlayer
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Number = x.Number,
                PlayerId = x.PlayerId,
                Position = x.Position,
                TeamId = x.TeamId,
                TeamName = x.Team.TeamName,
            }).ToList();
        }
    }
}
