using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.Profile;

namespace Typer.Services.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IAppUserAccess _userAppAccess;
        private readonly ITeamAccess _teamAccess;

        public ProfileService(IAppUserAccess userAppAccess, ITeamAccess teamAccesss)
        {
            _userAppAccess = userAppAccess;
            _teamAccess = teamAccesss;
        }

        public VMManageIndex GetUserDetails(string userId)
        {
            var userDetails = _userAppAccess.GetUserDetails(userId);
            return new VMManageIndex
            {
                Name = userDetails.Name,
                Surname = userDetails.Surname,
                Username = userDetails.Username,
                FavoriteTeam = new VMTeam { TeamId = userDetails.FavoriteTeam.TeamId, TeamName = userDetails.FavoriteTeam.TeamName},
                Email = userDetails.Email,
                FavoriteTeamId = userDetails.FavoriteTeam.TeamId      
            };
        }

        public void ChangeUserDetails(VMManageIndex userDetails)
        {
            var coreUserDetails = new CoreChangeUserDetails
            {
                Surname = userDetails.Surname,
                Email = userDetails.Email,
                FavoriteTeamId = userDetails.FavoriteTeamId,
                Name = userDetails.Name,
                Username = userDetails.Username,
                Id = userDetails.Id
            };
            _userAppAccess.ChangeUserDetails(coreUserDetails);
        }
    }
}
