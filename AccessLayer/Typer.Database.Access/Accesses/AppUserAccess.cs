using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels;
using Typer.CoreModels.Models;
using Typer.Database.Migrations;

namespace Typer.Database.Access
{
    public class AppUserAccess : IAppUserAccess
    {
        private TyperContext _context;
        public AppUserAccess()
        {
            _context = new TyperContext();
        }
        public CoreUserDetails GetUserDetails(string userId)
        {
            var user = _context.DbAppUsers
                    .Where(x => x.Id == userId)
                    .Select(y => new CoreUserDetails
                    {
                        Surname = y.Surname ?? "nie podano",
                        Email = y.Email ?? "nie podano",
                        Name = y.Name ?? "nie podano",
                        Username = y.UserName ?? "nie podano",
                        FavoriteTeam = new CoreTeam
                        {
                            TeamId = y.FavoriteTeam != null ? y.FavoriteTeam.TeamId : 0,
                            TeamName = y.FavoriteTeam != null ? y.FavoriteTeam.TeamName : "nie podano"
                        }
                    }).FirstOrDefault();
            return user;
                    
        }
        public void ChangeUserDetails(CoreChangeUserDetails userDetails)
        {
            var user = _context.DbAppUsers.FirstOrDefault(x => x.Id == userDetails.Id);
            user.FavoriteTeamId = userDetails.FavoriteTeamId ?? null;
            user.Name = userDetails.Name;
            user.Surname = userDetails.Surname;
            _context.SaveChanges();
        }
    }
}
