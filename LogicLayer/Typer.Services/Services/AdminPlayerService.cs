using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminPlayer;

namespace Typer.Services.Services
{
    public class AdminPlayerService : IAdminPlayerService
    {
        private readonly IPlayerAccess _playerAccess;
        public AdminPlayerService(IPlayerAccess playerAccess)
        {
            _playerAccess = playerAccess;
        }

        public VMAdminPlayerIndex GetAdminPlayerIndex()
        {
            var corePlayers = _playerAccess.GetPlayers();
            var vmPlayers = corePlayers.Select(x => new VMPlayer
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Number = x.Number,
                PlayerId = x.PlayerId,
                Position = x.Position,
                TeamId = x.TeamId,
                TeamName = x.TeamName
            }).ToList();

            var model = new VMAdminPlayerIndex
            {
                Players = vmPlayers
            };
            return model;
        }
    }
}
